namespace AxiosAnnotations.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Custom required attribute 
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.RequiredAttribute" />
    public class AxiosRequiredAttribute : RequiredAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AxiosRequiredAttribute"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message to associate with a validation control.</param>
        public AxiosRequiredAttribute(string errorMessage = null)
        {
            ErrorMessage = errorMessage ?? "This attribute is required";
            AllowEmptyStrings = false;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
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
