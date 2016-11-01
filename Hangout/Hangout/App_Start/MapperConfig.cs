using AutoMapper;
using HangOut.Models;

namespace HangOut
{
    public static class MapperConfig
    {
        public static IMapper GetMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookingViewModel, Booking>();
                cfg.CreateMap<Booking, BookingViewModel>();
                cfg.CreateMap<PlaceViewModel, Place>();
                cfg.CreateMap<Review, CommentsViewModel>();
                cfg.CreateMap<Place, PlaceViewModel>();

                cfg.CreateMap<HotelViewModel, Place>();
                cfg.CreateMap<HotelViewModel, Hotel>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Place, HotelViewModel>();
                cfg.CreateMap<Hotel, HotelViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<HospitalViewModel, Place>();
                cfg.CreateMap<HospitalViewModel, Hospital>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Place, HospitalViewModel>();
                cfg.CreateMap<Hospital, HospitalViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));

                cfg.CreateMap<FoodViewModel, Place>();
                cfg.CreateMap<FoodViewModel, Resturant>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Place, FoodViewModel>();
                cfg.CreateMap<Resturant, FoodViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, Hospital>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Hospital, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));

                cfg.CreateMap<PlaceViewModel, Clinic>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Clinic, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, Education>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Education, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, Resturant>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Resturant, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, Laboratory>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Laboratory, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, Pharmacy>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Pharmacy, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, RealEstate>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<RealEstate, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));


                cfg.CreateMap<PlaceViewModel, Shopping>()
                .ForMember(x => x.Place, opt => opt.MapFrom(src => src));
                cfg.CreateMap<Shopping, PlaceViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Place.Description))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(x => x.BuildingNo, opt => opt.MapFrom(src => src.Place.BuildingNo))
                .ForMember(x => x.RoadName, opt => opt.MapFrom(src => src.Place.RoadName))
                .ForMember(x => x.Town, opt => opt.MapFrom(src => src.Place.Town))
                .ForMember(x => x.EmailAddress, opt => opt.MapFrom(src => src.Place.EmailAddress))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.Place.PhoneNumber))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Place.Id))
                .ForMember(x => x.OpenTime, opt => opt.MapFrom(src => src.Place.OpenTime))
                .ForMember(x => x.CloseTime, opt => opt.MapFrom(src => src.Place.CloseTime));
            }).CreateMapper();
        }
    }
}