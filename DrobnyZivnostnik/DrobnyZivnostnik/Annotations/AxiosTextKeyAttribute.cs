namespace DrobnyZivnostnik.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AxiosTextKeyAttribute : Attribute
    {
        public string LocalizationKey { get; set; }

        public AxiosTextKeyAttribute(string textKey)
        {
            LocalizationKey = textKey;
        }
    }
}
