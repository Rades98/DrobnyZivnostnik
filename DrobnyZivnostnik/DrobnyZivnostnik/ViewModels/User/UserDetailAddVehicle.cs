namespace DrobnyZivnostnik.ViewModels.User
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models.Vehicle;
    using Services.Interfaces;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Threading.Tasks;
    using Common;

    public class UserDetailAddVehicle : CommonDetailViewModel<VehicleModel>
    {
        private readonly IVehicleService _vehicleService = DependencyService.Resolve<IVehicleService>();

        public ICommand SaveCommand { get; set; }

        public ObservableCollection<string> FuelType => new ObservableCollection<string>()
        {
            LocalizationService.GetResourceByKey("Axios.Values.FuelType.Diesel"),
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
            else
            {
                await MessageService.ShowErrorsAsync(Errors);
                Errors.Clear();
            }
        }
    }
}