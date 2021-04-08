namespace DrobnyZivnostnik.Annotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    class AxiosRequiredInGroupAttribute : ValidationAttribute
    {
        public string GroupName { get; }

        public AxiosRequiredInGroupAttribute(string groupName)
            : base("Axios.Annotations.RequiredInGroup")
        {
            GroupName = groupName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var properties = GetInvolvedProperties(validationContext.ObjectType);

            var values = properties.Where(p => p.Key.Name != validationContext.MemberName)
                .Select(p => p.Key.GetValue(validationContext.ObjectInstance));

            return values.Count(s => !string.IsNullOrWhiteSpace(Convert.ToString(s))) >= 1
                ? ValidationResult.Success
                : new ValidationResult(GetErrorMessage(properties.Values), new List<string> { validationContext.MemberName });
        }

        private Dictionary<PropertyInfo, string> GetInvolvedProperties(Type type)
        {
            return type.GetProperties()
                .Where(p => p.IsDefined(typeof(AxiosRequiredInGroupAttribute)) &&
                            p.GetCustomAttribute<AxiosRequiredInGroupAttribute>().GroupName == GroupName)
                .ToDictionary(p => p,
                    p => p.IsDefined(typeof(DisplayAttribute))
                        ? p.GetCustomAttribute<DisplayAttribute>().Name
                        : p.Name);
        }

        private string GetErrorMessage(IEnumerable<string> properties)
        {
            var errorMessage = string.Format(ErrorMessageString);
            errorMessage += ": " + string.Join(", ", properties);
            return errorMessage;
        }
    }
}
