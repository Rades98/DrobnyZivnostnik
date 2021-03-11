namespace DrobnyZivnostnik.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Models.MasterPage;
    using Xamarin.Forms;
    using static Xamarin.Forms.Application;

    public class MasterViewModel : BaseViewModel
    {
        public MasterPageItem SelectedItem { get; set; }

        public ICommand OnItemSelectCommand { get; set; }

        public MasterViewModel()
        {
            OnItemSelectCommand = new Command(async () => await GoToSelectedPage());
        }

        private async Task GoToSelectedPage()
        {
            if (Current.MainPage is MasterDetailPage navPage)
            {
                await navPage.Detail.Navigation.PushAsync((ContentPage)Activator.CreateInstance(SelectedItem.TargetType));
                navPage.IsPresented = false;
            }
        }
    }
}
