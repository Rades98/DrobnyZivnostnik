namespace DrobnyZivnostnik.ViewModels.Common
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using AxiosControls.Controls.LayoutControls;
    using AxiosServices.Services.Interfaces;
    using Xamarin.Forms;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public readonly IMessageService MessageService;
        public readonly ILocalizationService LocalizationService;

        protected BaseViewModel()
        {
            MessageService = DependencyService.Get<IMessageService>();
            LocalizationService = DependencyService.Get<ILocalizationService>();
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void GoToPage(Type targetType)
        {
            if ((!(Application.Current.MainPage is MasterDetailPage mainPage)))
            {
                return;
            }

            mainPage.Navigation.PushModalAsync((AxiosContentPage)Activator.CreateInstance(targetType));
            mainPage.IsPresented = false;
        }

        public static void BackFromActualPage()
        {
            if ((Application.Current.MainPage is MasterDetailPage mainPage))
            {
                mainPage.Navigation.PopModalAsync();
            }
        }
    }
}
