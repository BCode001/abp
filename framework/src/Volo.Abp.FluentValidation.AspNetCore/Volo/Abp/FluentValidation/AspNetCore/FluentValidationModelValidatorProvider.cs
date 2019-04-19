using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Volo.Abp.FluentValidation.AspNetCore
{
    public class FluentValidationModelValidatorProvider : IModelValidatorProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public FluentValidationModelValidatorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateValidators(ModelValidatorProviderContext context)
        {
            var modelValidator = (IModelValidator) _serviceProvider.GetService(typeof(ModelFluentValidator));
            if (modelValidator != null)
            {
                context.Results.Add(new ValidatorItem
                {
                    IsReusable = false,
                    Validator = modelValidator
                });
            }

        }
    }
}
