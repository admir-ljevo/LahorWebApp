using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Dto.ApplicationRole;
using Lahor.Core.Dto.City;
using Lahor.Core.Dto.Country;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Dto.New;
using Lahor.Core.Dto.Note;
using Lahor.Core.Dto.OrderDto;
using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.ServicesLevelsPrices;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.Dto.TypeOfServiceWithoutServices;
using Lahor.Core.Entities;
using Lahor.Core.Entities.Identity;
using Lahor.Reporting.Models;

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
            CreateMap<ApplicationRole, ApplicationRoleDto>()
                .ReverseMap();

            CreateMap<Person, EntityItemDto>().
                    ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                    ForMember(x => x.Label, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));

            CreateMap<PersonDto, Person>().ReverseMap();

            CreateMap<ApplicationUserDto, ApplicationUser>()
                    .ForMember(au => au.Roles, auDto => auDto.MapFrom(x => x.UserRoles))
                    .ReverseMap();


            #endregion

            #region Country

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CountryDto, CountryInsertDto>().ReverseMap();
            CreateMap<CountryDto, CountryUpdateDto>().ReverseMap();
            CreateMap<CountryDto, EntityItemDto>().
                    ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                    ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));

            #endregion

            #region City

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CityDto, CityInsertDto>().ReverseMap();
            CreateMap<CityDto, CityUpdateDto>().ReverseMap();
            CreateMap<CityDto, EntityItemDto>().
                    ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                    ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));

            #endregion

            #region Note

            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<NotificationDto, NotificationInsertDto>().ReverseMap();

            #endregion

            #region Order

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderUpsertDto>().ReverseMap();

            #endregion

            #region New

            CreateMap<New, NewDto>().ReverseMap();
            CreateMap<NewDto, NewInsertDto>().ReverseMap();
            CreateMap<NewDto, NewUpdateDto>().ReverseMap();

            #endregion

            #region Person

            CreateMap<Person, PersonDto>().ReverseMap();

            #endregion

            #region Service

            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<ServiceDto, ServiceUpsertDto>().ReverseMap();

            #endregion

            #region TypeOfService

            CreateMap<TypeOfService, TypeOfServiceDto>().ReverseMap();
            CreateMap<TypeOfService, TypeOfServiceWithoutServicesDto>().ReverseMap();
            CreateMap<TypeOfServiceWithoutServicesDto, TypeOfServiceDto>().ReverseMap();
            CreateMap<TypeOfServiceDto, TypeOfServiceUpsertDto>().ReverseMap();
            CreateMap<TypeOfService, TypeOfServiceWithoutServiceListDto>().ReverseMap();

            #endregion

            #region ServicesLevelsPrice

            CreateMap<ServicesLevelsPrice, ServicesLevelsPriceDto>().ReverseMap();

            #endregion

            #region ServicesLevelsPrice

            CreateMap<LevelOfServiceExecution, LevelOfServiceExecutionDto>().ReverseMap();

            #endregion

            #region EmployeeReport

            CreateMap<ApplicationUser, EmployeeReportModel>().
                    ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.Person.FirstName)).
                    ForMember(x => x.LastName, opt => opt.MapFrom(x => x.Person.LastName)).
                    ForMember(x => x.DateOfEmployment, opt => opt.MapFrom(x => x.Person.DateOfEmployment.Value.ToString("dd.MM.yyyy"))).
                    ForMember(x => x.Pay, opt => opt.MapFrom(x => x.Person.Pay)).
                    ForMember(x => x.Address, opt => opt.MapFrom(x => x.Person.Address)).
                    ForMember(x => x.Position, opt => opt.MapFrom(x => x.Person.Position.ToString()));

            #endregion

            #region ClientReport

            CreateMap<ApplicationUser, ClientReportModel>().
                    ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.Person.FirstName)).
                    ForMember(x => x.LastName, opt => opt.MapFrom(x => x.Person.LastName)).
                    ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.Person.CreatedAt.ToString("dd.MM.yyyy"))).
                    ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber)).
                    ForMember(x => x.Address, opt => opt.MapFrom(x => x.Person.Address)).
                    ForMember(x => x.BirthDate, opt => opt.MapFrom(x => x.Person.BirthDate.ToString("dd.MM.yyyy")));

            #endregion

        }
    }
}
