using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;
using Volo.Abp.Validation;

namespace Volo.Abp.FluentValidation.AspNetCore
{
    public class ModelFluentValidator : FluentValidator, IModelValidator
    {
        public ModelFluentValidator(IOptions<AbpValidationOptions> options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        {
        }

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var errors = new List<ValidationResult>();

            ValidateObjectRecursively(errors, context.Model, 1);

            return errors.Select(x => new ModelValidationResult(string.Join(",", x.MemberNames), x.ErrorMessage));
        }
    }
}