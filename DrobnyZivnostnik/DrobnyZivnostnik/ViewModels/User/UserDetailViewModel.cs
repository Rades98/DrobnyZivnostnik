namespace DrobnyZivnostnik.ViewModels.User
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Common;
    using Models.Address;
    using Models.User;
    using Models.Vehicle;
    using Services.Interfaces;
    using Views.User;
    using Xamarin.Forms;

    public sealed class UserDetailViewModel : CommonDetailViewModel<UserModel>
    {
        private readonly IUserService _userService = DependencyService.Resolve<IUserService>();
        private readonly IVehicleService _vehicleService = DependencyService.Resolve<IVehicleService>();

        public ObservableCollection<VehicleModel> Vehicles { get; set; }
        public AddressModel Address { get; set; }

        public ICommand AddVehicle { get; set; }
        public ICommand DeleteCommand { get; set; }

        public UserDetailViewModel()
        {
            RefreshAsyncSource();
            DeleteCommand = new Command(async (x) => await DeleteVehicle(x));
            AddVehicle = new Command(() => GoToPage(typeof(User_AddVehicleView)));
        }

        public override async Task<UserModel> GetDataAsync()
        {
            return await _userService.GetAsync();
        }
        
        private async Task DeleteVehicle(object sender)
        {
            if (sender is VehicleModel selected)
            {
                await _vehicleService.DeleteAsync(selected.VehicleId);
                RefreshAsyncSource();
            }
        }

        public override Task CustomRefresh()
        {
            Vehicles = Model.Vehicles;
            OnPropertyChanged(nameof(Vehicles));

            Address = Model.Address;
            OnPropertyChanged(nameof(Address));

            return Task.CompletedTask;
        }
    }
}