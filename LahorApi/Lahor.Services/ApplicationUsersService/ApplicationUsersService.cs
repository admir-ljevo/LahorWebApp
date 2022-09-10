using Lahor.Core.Dto;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.ApplicationUserRolesService;

namespace Lahor.Services.ApplicationUsersService
{
    public class ApplicationUsersService:IApplicationUsersService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IApplicationUserRolesService _applicationUserRolesService;

        public ApplicationUsersService(IUnitOfWork unitOfWork, IApplicationUserRolesService applicationUserRolesService)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
            _applicationUserRolesService = applicationUserRolesService;
        }


        public async Task<ApplicationUserDto> AddAsync(ApplicationUserDto entityDto)
        {
            var user = await _unitOfWork.ApplicationUsersRepository.AddAsync(entityDto);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<ApplicationUserDto> UpdateAsync(ApplicationUserDto entityDto)
        {
            var result = await _unitOfWork.ExecuteAsync(async () =>
            {
                //await _unitOfWork.ApplicationUserRolesRepository.SetTrackedValues(entityDto.UserRoles);
                //_unitOfWork.PersonRepository.Update(entityDto.Person);

                //entityDto.UserRoles = null;
                //entityDto.Person = null;

                _unitOfWork.ApplicationUsersRepository.Update(entityDto);

            });

            return entityDto;
        }

        public Task<ApplicationUserDto> FindByUserNameAsync(string pUserName)
        {
            return _unitOfWork.ApplicationUsersRepository.FindByUserNameAsync(pUserName);
        }

        public Task<List<ApplicationUserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUserDto entity)
        {
            throw new NotImplementedException();
        }

    }
}
