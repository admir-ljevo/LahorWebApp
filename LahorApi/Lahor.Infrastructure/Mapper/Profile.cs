using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Dto.Device;
using Lahor.Core.Dto.DeviceBrand;
using Lahor.Core.Dto.DeviceType;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Dto.Material;
using Lahor.Core.Dto.MaterialRequests;
using Lahor.Core.Dto.New;
using Lahor.Core.Dto.Note;
using Lahor.Core.Dto.Order;
using Lahor.Core.Dto.OrdersServicesLevels;
using Lahor.Core.Dto.PurchaseRequest;
using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.ServicesLevelsPrices;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.Entities;
using Lahor.Core.Entities.Identity;

namespace Lahor.Infrastructure.Mapper
{
    public class Profiles:Profile
    {

        public Profiles()
        {
            #region User

            CreateMap<ApplicationUserRole, ApplicationUserRoleDto>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Person, EntityItemDto>().
                    ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                    ForMember(x => x.Label, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));

            CreateMap<PersonDto, Person>().ReverseMap();

            CreateMap<ApplicationUserDto, ApplicationUser>()
                    .ForMember(au => au.Roles, auDto => auDto.MapFrom(x => x.UserRoles))
                    .ReverseMap();

            CreateMap<Person, ApplicationUserDto>().ForMember(au => au.PersonId, p => p.MapFrom(p => p.Id));


            #endregion

            #region Country

            CreateMap<Country, EntityItemDto>().
                    ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                    ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));
            CreateMap<Country, CountryDto>().ReverseMap();

            #endregion

            #region City

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, EntityItemDto>().
                    ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                    ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));

            #endregion

            #region Note

            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<NoteDto, NoteInsertDto>().ReverseMap();

            #endregion

            #region Order

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderUpsertDto>().ReverseMap();

            #endregion

            #region PurchaseRequest

            CreateMap<PurchaseRequest, PurchaseRequestDto>().ReverseMap();  
            CreateMap<PurchaseRequestDto, PurchaseRequestUpsertDto>().ReverseMap();

            #endregion

            #region MaterialRequests

            CreateMap<MaterialRequests, MaterialRequestsDto>().ReverseMap();
            CreateMap<MaterialRequestsDto, MaterialRequestsUpsertDto>().ReverseMap(); 

            #endregion


            #region Material

            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<MaterialDto, MaterialUpsertDto>().ReverseMap();

            #endregion

            #region New

            CreateMap<New, NewDto>().ReverseMap();
            CreateMap<NewDto, NewInsertDto>().ReverseMap();
            CreateMap<NewDto, NewUpdateDto>().ReverseMap();

            #endregion

            #region Person

            CreateMap<Person, PersonDto>().ReverseMap();

            #endregion

            #region Device

            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<DeviceDto, DeviceUpsertDto>().ReverseMap();

            #endregion

            #region DeviceBrand

            CreateMap<DeviceBrand, DeviceBrandDto>().ReverseMap();
            CreateMap<DeviceBrandDto, DeviceBrandUpsertDto>().ReverseMap();

            #endregion
            
            #region DeviceType

            CreateMap<DeviceType, DeviceTypeDto>().ReverseMap();
            CreateMap<DeviceTypeDto, DeviceTypeUpsertDto>().ReverseMap();

            #endregion

            #region Service

            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<ServiceDto, ServiceUpsertDto>().ReverseMap();

            #endregion

            #region TypeOfService

            CreateMap<TypeOfService, TypeOfServiceDto>().ReverseMap();
            CreateMap<TypeOfServiceDto, TypeOfServiceUpsertDto>().ReverseMap();
            CreateMap<TypeOfService, TypeOfServiceWithoutServiceListDto>().ReverseMap();

            #endregion

            #region ServicesLevelsPrice

            CreateMap<ServicesLevelsPrice, ServicesLevelsPriceDto>().ReverseMap();

            #endregion

            #region ServicesLevelsPrice

            CreateMap<LevelOfServiceExecution, LevelOfServiceExecutionDto>().ReverseMap();

            #endregion

            #region OrdersServicesLevels

            CreateMap<OrdersServicesLevels, OrdersServicesLevelsDto>().ReverseMap();
            CreateMap<OrdersServicesLevelsDto, OrdersServiceLevelsUpsertDto>().ReverseMap();

            #endregion

        }
    }
}
