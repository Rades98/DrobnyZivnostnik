namespace DrobnyZivnostnik.ViewModels.User
{
    using Services.Interfaces;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Models.User;
    using Views;
    using Views.User;
    using Xamarin.Forms;

    public sealed class UserListViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        public UserModel SelectedItem { get; set; }
        public ICommand UserDetailCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<UserListModel> UserModels
        {
            get
            {
                var task = Task.Run(async () => await GetDataAsync());
                task.Wait();
                return new ObservableCollection<UserListModel>(task.Result);
            }
        }

        public UserListViewModel()
        {
            _userService = DependencyService.Resolve<IUserService>();

            UserDetailCommand = new Command(async () => await SetUser());
            DeleteCommand = new Command(async () => await Delete());
        }

        private async Task Delete()
        {
            await _userService.DeleteAsync(SelectedItem.UserId);
            OnPropertyChanged(nameof(UserModels));
        }

        private async Task<ObservableCollection<UserListModel>> GetDataAsync()
        {
            return new ObservableCollection<UserListModel>(await _userService.GetUserListAsync());
        }

        private async Task SetUser()
        {
            await _userService.SetUserActive(SelectedItem.UserId);
            await Application.Current.MainPage.Navigation.PushAsync(new UserSettingsView());
        }
    }
}
