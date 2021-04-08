namespace DrobnyZivnostnik.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Annotations;
    using Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    public class LocalizationService : ILocalizationService
    {
        /// <inheritdoc />
        public string GetResourceByKey(string key)
        {
            //I know that those tries look like bullshit, but it works :) dunno how dunno why

            Application.Current.Resources.TryGetValue(key, out var resource);
            if (resource != null)
            {
                return resource.ToString();
            }

            //secondTry
            Application.Current.Resources.TryGetValue(key, out var res);
            if (res != null)
            {
                return res.ToString();
            }

            //thirdTry
            Application.Current.Resources.TryGetValue(key, out var r);
            if (r != null)
            {
                return r.ToString();
            }

            //Debug.WriteLine($"Error: Default translation not found in LocalizationResource.xaml. Key: {key}");
            Debug.WriteLine($"<s:String x:Key=\"{key}\">-</s:String> is missing, add it to LocalizationResource.xaml");
            return key;
        }

        public string GetResourceByKey(Type objType)
        {
            return GetResourceByKey(GetLocalizationKeyFromType(objType));
        }

        public string GetResourceByKey(PropertyInfo prop)
        {
            return GetResourceByKey(GetLocalizationKeyFromPropertyInfo(prop));
        }

        /// <inheritdoc />
        public string GetLocalizationKeyFromType(Type objType)
        {
            var locKeys = new List<string>();
             objType.GetProperties().ForEach(prop => { locKeys.Add(GetLocalizationKeyFromPropertyInfo(prop)); });

             return locKeys.FirstOrDefault();
        }

        /// <inheritdoc />
        public string GetLocalizationKeyFromPropertyInfo(PropertyInfo prop)
        {
            var locKey = prop.GetCustomAttributes(typeof(AxiosTextKeyAttribute), false);

            if (locKey.Length < 1)
            {
                return prop.Name;
            }

            if (locKey[0] is AxiosTextKeyAttribute lk)
            {
                return lk.LocalizationKey;
            }

            return prop.Name;
        }
    }
}
