namespace DrobnyZivnostnik.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Controls;
    using Xamarin.Forms;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
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
