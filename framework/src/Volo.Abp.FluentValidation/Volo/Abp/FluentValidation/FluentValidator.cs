using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Reflection;
using Volo.Abp.Validation;

namespace Volo.Abp.FluentValidation
{
    public class FluentValidator : IObjectValidator, ITransientDependency
    {
        private readonly AbpValidationOptions _options;
        private readonly IServiceProvider _serviceProvider;

        public FluentValidator(IOptions<AbpValidationOptions> options, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _options = options.Value;
        }

        public void Validate(object validatingObject, string name = null, bool allowNull = false)
        {
            var errors = GetErrors(validatingObject, name, allowNull);

            if (errors.Any())
            {
                //TODO: How to localize messages?
                throw new AbpValidationException(
                    "Object state is not valid! See ValidationErrors for details.",
                    errors
                );
            }
        }

        public List<ValidationResult> GetErrors(object validatingObject, string name = null, bool allowNull = false)
        {
            var errors = new List<ValidationResult>();

            ValidateObjectRecursively(errors, validatingObject, 1);

            return errors;
        }

        protected virtual void ValidateObjectRecursively(List<ValidationResult> errors, object validatingObject,
            int currentDepth)
        {
            const int maxRecursiveParameterValidationDepth = 8;

            if (currentDepth > maxRecursiveParameterValidationDepth)
            {
                return;
            }

            if (validatingObject == null)
            {
                return;
            }

            errors.AddRange(GetDataAnnotationErrors(validatingObject));

            //Validate items of enumerable
            if (validatingObject is IEnumerable)
            {
                if (!(validatingObject is IQueryable))
                {
                    foreach (var item in validatingObject as IEnumerable)
                    {
                        ValidateObjectRecursively(errors, item, currentDepth + 1);
                    }
                }

                return;
            }

            var validatingObjectType = validatingObject.GetType();

            //Do not recursively validate for primitive objects
            if (TypeHelper.IsPrimitiveExtended(validatingObjectType))
            {
                return;
            }

            if (_options.IgnoredTypes.Any(t => t.IsInstanceOfType(validatingObject)))
            {
                return;
            }

            var properties = TypeDescriptor.GetProperties(validatingObject).Cast<PropertyDescriptor>();
            foreach (var property in properties)
            {
                if (property.Attributes.OfType<DisableValidationAttribute>().Any())
                {
                    continue;
                }

                ValidateObjectRecursively(errors, property.GetValue(validatingObject), currentDepth + 1);
            }
        }

        public virtual List<ValidationResult> GetDataAnnotationErrors(object validatingObject)
        {
            var errors = new List<ValidationResult>();

            var serviceType = typeof(IValidator<>).MakeGenericType(validatingObject.GetType());
            if (!(_serviceProvider.GetService(serviceType) is IValidator validator))
            {
                return errors;
            }

            var result = validator.Validate(validatingObject);
            if (!result.IsValid)
            {
                //TODO: How to localize  Fluent Validation messages?
                errors.AddRange(
                    result.Errors.Select(
                        error =>
                            new ValidationResult(error.ErrorMessage)
                    )
                );
            }

            return errors;
        }
    }
}