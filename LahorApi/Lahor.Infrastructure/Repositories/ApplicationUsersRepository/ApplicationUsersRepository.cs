using AutoMapper;
using Lahor.Core.Dto;
using Lahor.Core.Dto.Service;
using Lahor.Core.Entities.Identity;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.Repositories.BaseRepository;
using Lahor.Reporting.Models;

namespace Lahor.Infrastructure.Repositories.ApplicationUsersRepository
{
    public class ApplicationUsersRepository : BaseRepository<ApplicationUser, int>, IApplicationUsersRepository
    {
        public ApplicationUsersRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ApplicationUserDto> FindByUserNameOrEmailAsync(string UserName)
        {
            return await ProjectToFirstOrDefaultAsync<ApplicationUserDto>(DatabaseContext.Users.Where(c => (c.UserName == UserName || c.Email==UserName) && c.Active==true));
        }

        public async Task<List<int>> GetEmployeesClientsCountByMonth(bool isEmployee,bool isClient)
        {
            int currentMonth = DateTime.Now.Month;
            int month;
            var listUsersCount = new List<int>();
            for (int i = currentMonth-11; i <= currentMonth; i++)
            {
                month = i;
                if(i<=0)
                {
                    month += 12;
                }
                listUsersCount.Add(DatabaseContext.Users.Where(x => x.IsEmployee == isEmployee && x.IsClient==isClient && x.IsDeleted == false && x.Active && x.CreatedAt.Month==month).Count());

            }
            return listUsersCount;
        }

        public async new Task<List<ApplicationUserDto>> GetEmployees()
        {
            var employees = await ProjectToListAsync<ApplicationUserDto>(DatabaseContext.Users.Where(x => x.IsEmployee==true && x.IsDeleted==false && x.Active==true));
            foreach (var item in employees)
            {
                item.Person.PositionName = item.Person.Position.ToString();
            }
            return employees;
        }

        public async new Task<List<ApplicationUserDto>> GetClients()
        {
            return await ProjectToListAsync<ApplicationUserDto>(DatabaseContext.Users.Where(x =>x.Active==true && x.IsClient == true && x.IsDeleted == false));  
        }
        public async Task<ApplicationUserDto> GetByIdAsync(int id)
        {
            var user= await ProjectToFirstOrDefaultAsync<ApplicationUserDto>(DatabaseContext.Users.Where(x=> x.IsDeleted == false && x.Id == id));
            user.Person.GenderName = user.Person.Gender.ToString();
            user.Person.DrivingLicenceName = user.Person.DrivingLicence.ToString();
            user.Person.MarriageStatusName = user.Person.MarriageStatus.ToString();
            user.Person.PositionName = user.Person.Position.ToString();
            return user;
        }

        public async new Task<List<EmployeeReportModel>> GetEmployeesReportData(ReportSearchObject search)
        {
            return await ProjectToListAsync<EmployeeReportModel>(DatabaseContext.Users.Where(x => x.IsDeleted == false && x.Active==true && x.IsEmployee==true && x.CreatedAt >= search.DateFrom && x.CreatedAt <= search.DateTo));
        }

        public async new Task<List<ClientReportModel>> GetClientsReportData(ReportSearchObject search)
        {
            return await ProjectToListAsync<ClientReportModel>(DatabaseContext.Users.Where(x => x.IsDeleted == false && x.Active == true && x.IsClient==true && x.CreatedAt >= search.DateFrom && x.CreatedAt <= search.DateTo));
        }

    }
}
