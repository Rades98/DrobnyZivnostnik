
namespace DrobnyZivnostnik
{
    using System.Diagnostics;
    using Xamarin.Forms;

    public static class Utils
    {
        /// <summary>
        /// Gets the resource by key.
        /// I know that those tries look like bullshit, but it works :) dunno how dunno why
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetResourceByKey(string key)
        {
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
            Debug.WriteLine($"<s:String x:Key=\"{key}\">-</s:String> is missing, add it to LocalizationResource.xaml"); // Generates missing keys fro LocalizationResource
            return key;
        }
    }
}
