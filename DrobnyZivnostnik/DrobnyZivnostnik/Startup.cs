namespace DrobnyZivnostnik
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Database;
    using Database.Entities;
    using Models.Address;
    using Models.TravelOrder;
    using Models.User;
    using Models.Vehicle;
    using Services;
    using Services.Interfaces;
    using Xamarin.Forms;

    /// <summary>
    /// Custom startup - made because of testing 
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Customs initialized method 
        /// </summary>
        public static void Initialized()
        {
            DependencyService.RegisterSingleton(CreateAutoMapper());
            DependencyService.Register<IAppDbContext, AppDbContext>();

            //Other services
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<ILocalizationService, LocalizationService>();

            //Data based Services
            DependencyService.Register<IAddressService, AddressService>();
            DependencyService.Register<IUserService, UserService>();
            DependencyService.Register<IVehicleService, VehicleService>();
            DependencyService.Register<ITravelOrderService, TravelOrderService>();
            

#if DEBUG
            var task = Task.Run(async () => await PseudoSeedAsync()); // ONLY FOR DEBUG
            task.Wait();
#endif
        }

        /// <summary>
        /// Creates the automatic mapper.
        /// </summary>
        /// <returns></returns>
        private static IMapper CreateAutoMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<AddressModel, Address>();

                cfg.CreateMap<TravelOrderFront, TravelOrderFrontModel>();
                cfg.CreateMap<TravelOrderFrontModel, TravelOrderFront>();

                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();

                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();
            }).CreateMapper();
        }

        /// <summary>
        /// Pseudoseed asynchronous.
        /// Adds data to db for testing
        /// </summary>
        /// <returns></returns>
        private static async Task PseudoSeedAsync()
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
        }
    }
}
