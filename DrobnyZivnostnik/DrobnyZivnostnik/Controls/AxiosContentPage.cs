namespace DrobnyZivnostnik.Controls
{
    using Xamarin.Forms;

    /// <summary>
    /// Custom content page for setting styles in ApplicationStyles.xaml
    /// and some other stuff in the future
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public class AxiosContentPage : ContentPage
    {

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            if (!(Application.Current.MainPage is MasterDetailPage mainPage))
            {
                return false;
            }

            mainPage.Navigation.PopModalAsync();

            return true;
        }
    }
}
