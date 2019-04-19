using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace Volo.Abp.AspNetCore.Mvc.Validation
{
    [Route("api/fluent-validation-test")]
    public class FluentValidationTestController : AbpController
    {
        [HttpGet]
        [Route("object-result-action")]
        public Task<string> ObjectResultAction(ValidationTest1Model model)
        {
            ModelState.IsValid.ShouldBeTrue(); //AbpValidationFilter throws exception otherwise
            return Task.FromResult(model.Value1);
        }

        [HttpGet]
        [Route("object-result-action2")]
        public Task<string> ObjectResultAction2(ValidationTest2Model model)
        {
            ModelState.IsValid.ShouldBeTrue(); //AbpValidationFilter throws exception otherwise
            return Task.FromResult(model.Value1);
        }

        [HttpGet]
        [Route("action-result-action")]
        public IActionResult ActionResultAction(ValidationTest1Model model)
        {
            return Content("ModelState.IsValid: " + ModelState.IsValid.ToString().ToLowerInvariant());
        }

        public class ValidationTest1Model
        {
            public string Value1 { get; set; }
        }

        public class ValidationTest1ModelValidator : AbstractValidator<ValidationTest1Model>
        {
            public ValidationTest1ModelValidator()
            {
                RuleFor(x => x.Value1).MinimumLength(2).NotNull();
            }
        }

        public class ValidationTest2Model
        {
            public ValidationTest2Model()
            {
                InnerModel = new ValidationTest2InnerModel();
            }

            [MinLength(2)]
            public string Value1 { get; set; }

            public ValidationTest2InnerModel InnerModel { get; set; }
        }

        public class ValidationTest2InnerModel
        {
            public string InnerValue1 { get; set; }
        }

        public class ValidationTest1InnerModelValidator : AbstractValidator<ValidationTest2InnerModel>
        {
            public ValidationTest1InnerModelValidator()
            {
                RuleFor(x => x.InnerValue1).MinimumLength(2).NotNull();
            }
        }
    }
}
