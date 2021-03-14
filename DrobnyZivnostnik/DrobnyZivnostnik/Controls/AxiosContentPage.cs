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
