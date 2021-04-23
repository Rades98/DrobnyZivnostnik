namespace DrobnyZivnostnik
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application;
    using Application.Models.Address;
    using Application.Models.TravelOrder;
    using Application.Models.User;
    using Application.Models.Vehicle;
    using Application.Services.Interfaces;
    using AxiosServices;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ConfigureServices(true);


            Task.Run(async () => await PseudoSeedAsync());

            MainPage = new MasterDetailPage
            {
                BackgroundColor = Color.Transparent, 
                Master = new MasterMenuView(), 
                Detail = new MainDetailView()
            };
        }

        private void ConfigureServices(bool dependencyService)
        {
            DependencyInjection.RegisterApplicationDependencies();
            AxiosServicesDependencyInjection.RegisterAxiosServices();
        }

        private async Task<bool> PseudoSeedAsync()
        {
            var addressService = DependencyService.Resolve<IAddressService>();
            var userService = DependencyService.Resolve<IUserService>();
            var vehicleSerice = DependencyService.Resolve<IVehicleService>();
            var travelOrderService = DependencyService.Resolve<ITravelOrderService>();

            var address = new AddressModel()
            {
                City = "Čeladná",
                Deleted = false,
                HouseNumber = "551",
                Street = "Čeladná 551",
                ZipCode = "73912"
            };


            await addressService.AddAsync(address);

            var addresses = await addressService.GetAsync();

            var id = addresses.FirstOrDefault().AddressId;

            var user = new UserModel()
            {
                Name = "Lenka",
                Surname = "Břenková",
                Deleted = false,
                AddressId = id,
                IdentifyingNumber = "02193761",
                CreationDate = DateTime.Now,
                ImagePath = "Users.png",
                PhoneNumber = "776 235 266"
            };

            await userService.AddAsync(user);

            var vehicle = new VehicleModel()
            {
                Name = "Škoda OCTAVIA II Combi",
                Deleted = false,
                FuelConsumption = 5.8,
                FuelType = "Diesel",
                NumberPlate = "4T5 4589",
                VehicleType = "O"
            };

            await vehicleSerice.AddAsync(vehicle);

            var vehicle2 = new VehicleModel()
            {
                Name = "Škoda FABIA III",
                Deleted = false,
                FuelConsumption = 8.8,
                FuelType = "Benzín",
                NumberPlate = "4T8 4565",
                VehicleType = "O"
            };

            await vehicleSerice.AddAsync(vehicle2);

            var travelOrder = new TravelOrderFrontModel()
            {
                Deleted = false,
                ArrivalTime = TimeSpan.Parse("8:00"),
                DepartmentTime = TimeSpan.Parse("18:00"),
                EndDate = DateTime.Now,
                EndPlace = "Kunčice p. O.",
                MeetingPurpose = "Pokecat s rodinkou",
                PlaceOfMeeting = "Domeček od Radka",
                StartDate = DateTime.Now,
                StartPlace = "Čeladná",
                TravelLength = TimeSpan.Parse("10:00")
            };

            await travelOrderService.AddAsync(travelOrder);

            return true;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
