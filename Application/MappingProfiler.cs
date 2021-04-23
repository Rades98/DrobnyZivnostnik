namespace Application
{
    using Models.Address;
    using Models.TravelOrder;
    using Models.User;
    using Models.Vehicle;
    using AutoMapper;
    using Domain.Entities;

    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<Address, AddressModel>();
            CreateMap<AddressModel, Address>();

            CreateMap<TravelOrderFront, TravelOrderFrontModel>();
            CreateMap<TravelOrderFrontModel, TravelOrderFront>();

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<Vehicle, VehicleModel>();
            CreateMap<VehicleModel, Vehicle>();
        }
    }
}
