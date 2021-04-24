namespace DrobnyZivnostnik.ViewModels.User
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Threading.Tasks;
    using Application.Models.Vehicle;
    using Application.Services.Interfaces;
    using Common;

    public class UserDetailAddVehicle : CommonDetailViewModel<VehicleModel>
    {
        private readonly IVehicleService _vehicleService = DependencyService.Resolve<IVehicleService>();

        public ICommand SaveCommand { get; set; }

        public ObservableCollection<string> FuelTypes => new ObservableCollection<string>()
        {
            LocalizationService.GetResourceByKey("Axios.Values.FuelType.CNG"),
            LocalizationService.GetResourceByKey("Axios.Values.FuelType.Diesel"),
            LocalizationService.GetResourceByKey("Axios.Values.FuelType.LPG"),
            LocalizationService.GetResourceByKey("Axios.Values.FuelType.Petrol")
        };

        public UserDetailAddVehicle()
        {
            Model = new VehicleModel();

            SaveCommand = new Command(async () => await AddVehicleAsync());
        }

        private async Task AddVehicleAsync()
        {
            if (ValidateModel())
            {
                await _vehicleService.AddAsync(Model);
                BackFromActualPage();
            }
        }
    }
}