using Lahor.Core.Dto.ApplicationRole;
using Lahor.Infrastructure.UnitOfWork;

namespace Lahor.Services.ApplicationRolesService
{
    public class ApplicationRolesService:IApplicationRolesService
    {
        public readonly UnitOfWork _unitOfWork;

        public ApplicationRolesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public Task AddRangeAsync(IEnumerable<ApplicationRoleDto> entitiesDto)
        {
            return _unitOfWork.ApplicationUserRolesRepository.AddRangeAsync(entitiesDto);
        }

        public Task<ApplicationRoleDto> AddAsync(ApplicationRoleDto country)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationRoleDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRoleDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRoleDto> GetByRoleLevelIdOrName(int roleLeveleId, string roleName)
        {
            return _unitOfWork.ApplicationRolesRepository.GetByRoleLevelOrName(roleLeveleId,roleName);
        }

        public Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            return _unitOfWork.ApplicationUserRolesRepository.RemoveByIdAsync(id);
        }

        public void Update(ApplicationRoleDto entity)
        {
            throw new NotImplementedException();
        }
        public void UpdateRange(IEnumerable<ApplicationRoleDto> entitiesDto)
        {
            _unitOfWork.ApplicationUserRolesRepository.UpdateRange(entitiesDto);
        }
    }
}
