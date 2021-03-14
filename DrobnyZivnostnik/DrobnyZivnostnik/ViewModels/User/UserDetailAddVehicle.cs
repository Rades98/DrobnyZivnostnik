namespace DrobnyZivnostnik.ViewModels.User
{
    using System.Collections.ObjectModel;
    using Models.Vehicle;
    using Services.Interfaces;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Threading.Tasks;

    public class UserDetailAddVehicle : BaseViewModel
    {
        private readonly IVehicleService _vehicleService = DependencyService.Resolve<IVehicleService>();

        public VehicleModel NewVehicle { get; set; } = new VehicleModel();

        public ICommand SaveCommand { get; set; }

        public ObservableCollection<string> FuelType => new ObservableCollection<string>()
        {
            Utils.GetResourceByKey("Axios.Values.FuelType.Diesel"),
            Utils.GetResourceByKey("Axios.Values.FuelType.Petrol")
        };

        public UserDetailAddVehicle()
        {
            SaveCommand = new Command(async () => await AddVehicleAsync());
        }

        private async Task AddVehicleAsync()
        {
            //TODO HANDLE INPUT
            await _vehicleService.AddAsync(NewVehicle);
            BackFromActualPage();
        }
    }
}