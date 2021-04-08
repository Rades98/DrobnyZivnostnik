namespace DrobnyZivnostnik.Annotations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class AxiosRequiredWhenNotNullAttribute : ValidationAttribute
    {
        public string ValidatedPropertyName { get; }

        public string DependentPropertyName { get; }

        private readonly AxiosRequiredAttribute _strictRequiredAttribute = new AxiosRequiredAttribute();


        public AxiosRequiredWhenNotNullAttribute(string validatedPropertyName, string propertyName)
        {
            ValidatedPropertyName = validatedPropertyName;
            DependentPropertyName = propertyName;
            ErrorMessage = _strictRequiredAttribute.ErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validateAgainstPropertyInfo = validationContext.ObjectType.GetProperty(DependentPropertyName);
            var validatedPropertyInfo = validationContext.ObjectType.GetProperty(ValidatedPropertyName);

            if (validateAgainstPropertyInfo == null || validatedPropertyInfo == null)
            {
                return null;
            }

            var instance = validateAgainstPropertyInfo.GetValue(validationContext.ObjectInstance);

            if (instance is null)
            {
                return _strictRequiredAttribute.GetValidationResult(validatedPropertyInfo.GetValue(validationContext.ObjectInstance), validationContext);
            }

            switch (instance)
            {
                case bool _:
                case string _:
                case int _:
                    break;
                case Guid guid:
                    if (guid == Guid.Empty)
                    {
                        return _strictRequiredAttribute.GetValidationResult(validatedPropertyInfo.GetValue(validationContext.ObjectInstance), validationContext);
                    }

                    break;
                default:
                    return _strictRequiredAttribute.GetValidationResult(validatedPropertyInfo.GetValue(validationContext.ObjectInstance), validationContext);
            }

            return null;
        }
    }
}
