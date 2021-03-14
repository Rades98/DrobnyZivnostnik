namespace DrobnyZivnostnik.ViewModels
{
    using Models.MasterPage;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MasterViewModel : BaseViewModel
    {
        public ICommand OnItemSelectCommand { get; set; }

        public MasterViewModel()
        {
            OnItemSelectCommand = new Command(GoToSelectedPage);
        }

        private static void GoToSelectedPage(object param)
        {
            if (!(param is MasterPageItem selectedItem))
            {
                return;
            }

            GoToPage(selectedItem.TargetType);
        }
    }
}
