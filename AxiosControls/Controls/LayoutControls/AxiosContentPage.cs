namespace AxiosControls.Controls.LayoutControls
{
    using Xamarin.Forms;

    /// <summary>
    /// Custom content page for setting styles
    /// and some other stuff in the future
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public class AxiosContentPage : ContentPage
    {
        //this should be managed somewhere else
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
