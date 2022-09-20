using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Dto.LevelOfServiceExecution;
using Lahor.Core.Dto.New;
using Lahor.Core.Dto.Note;
using Lahor.Core.Dto.OrderDto;
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
            CreateMap<TypeOfServiceDto, TypeOfServiceUpsertDto>().ReverseMap();
            CreateMap<TypeOfService, TypeOfServiceWithoutServiceListDto>().ReverseMap();

            #endregion

            #region ServicesLevelsPrice

            CreateMap<ServicesLevelsPrice, ServicesLevelsPriceDto>().ReverseMap();

            #endregion

            #region ServicesLevelsPrice

            CreateMap<LevelOfServiceExecution, LevelOfServiceExecutionDto>().ReverseMap();

            #endregion

        }
    }
}
