namespace DrobnyZivnostnik.Services.Interfaces
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public interface ILocalizationService
    {
        /// <summary>
        /// Gets the resource by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string GetResourceByKey(string key);

        /// <summary>
        /// Gets the resource by key.
        /// </summary>
        /// <param name="objType">The object type.</param>
        /// <returns></returns>
        string GetResourceByKey(Type objType);

        /// <summary>
        /// Gets the resource by key.
        /// </summary>
        /// <param name="prop">The property.</param>
        /// <returns></returns>
        string GetResourceByKey(PropertyInfo prop);

        /// <summary>
        /// Gets the type of the localization key from.
        /// </summary>
        /// <param name="objType">Type of the object.</param>
        /// <returns></returns>
        string GetLocalizationKeyFromType(Type objType);

        /// <summary>
        /// Gets the localization key from property information.
        /// </summary>
        /// <param name="prop">The property.</param>
        /// <returns></returns>
        string GetLocalizationKeyFromPropertyInfo(PropertyInfo prop);
    }
}
