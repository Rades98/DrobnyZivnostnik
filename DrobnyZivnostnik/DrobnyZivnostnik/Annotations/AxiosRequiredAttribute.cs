namespace DrobnyZivnostnik.Annotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    class AxiosRequiredAttribute : RequiredAttribute
    {
        public AxiosRequiredAttribute()
        {
            ErrorMessage = "Axios.Annotations.Required";
            AllowEmptyStrings = false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult(ErrorMessage, new List<string>() { validationContext.MemberName });
            }

            var type = value.GetType();

            if (type != typeof(Guid))
            {
                return !base.IsValid(value) ? new ValidationResult(ErrorMessage, new List<string>() { validationContext.MemberName }) : null;
            }

            return !Equals(value, Activator.CreateInstance(Nullable.GetUnderlyingType(type) ?? type)) ? null : new ValidationResult(ErrorMessage, new List<string>() { validationContext.MemberName });
        }
    }
}
