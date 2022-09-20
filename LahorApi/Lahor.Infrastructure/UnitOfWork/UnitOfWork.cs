
using Lahor.Infrastructure.Repositories.ApplicationUserRolesRepository;
using Lahor.Infrastructure.Repositories.ApplicationUsersRepository;
using Lahor.Infrastructure.Repositories.LevelOfServiceExecutionsRepository;
using Lahor.Infrastructure.Repositories.LogsRepository;
using Lahor.Infrastructure.Repositories.NewsRepository;
using Lahor.Infrastructure.Repositories.NotesRepository;
using Lahor.Infrastructure.Repositories.OrdersRepository;
using Lahor.Infrastructure.Repositories.ServicesLevelsPriceRepository;
using Lahor.Infrastructure.Repositories.ServicesRepository;
using Lahor.Infrastructure.Repositories.TypeOfServicesRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lahor.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public readonly IApplicationUsersRepository ApplicationUsersRepository;
        public readonly IApplicationUserRolesRepository ApplicationUserRolesRepository;
        public readonly ILogsRepository LogsRepository;
        public readonly INotesRepository NotesRepository;
        public readonly IOrdersRepository OrdersRepository;
        public readonly INewsRepository NewsRepository;
        public readonly IServicesRepository ServicesRepository;
        public readonly ITypeOfServicesRepository TypeOfServicesRepository;
        public readonly ILevelOfServiceExecutionsRepository LevelOfServiceExecutionsRepository;
        public readonly IServicesLevelsPriceRepository ServicesLevelsPriceRepository;
        public UnitOfWork(DatabaseContext databaseContext,IApplicationUserRolesRepository applicationUserRolesRepository,IApplicationUsersRepository applicationUsersRepository,
            ILogsRepository logsRepository,INotesRepository notesRepository,
            IOrdersRepository ordersRepository,INewsRepository newsRepository,
            IServicesRepository servicesRepository,ITypeOfServicesRepository typeOfServicesRepository,
            ILevelOfServiceExecutionsRepository levelOfServiceExecutionsRepository
            ,IServicesLevelsPriceRepository servicesLevelsPriceRepository)
        {
            _databaseContext = databaseContext;
            ApplicationUserRolesRepository=applicationUserRolesRepository;
            ApplicationUsersRepository=applicationUsersRepository;
            LogsRepository=logsRepository;
            NotesRepository = notesRepository;
            OrdersRepository = ordersRepository;
            NewsRepository = newsRepository;
            ServicesRepository = servicesRepository;
            TypeOfServicesRepository = typeOfServicesRepository;
            LevelOfServiceExecutionsRepository = levelOfServiceExecutionsRepository;
            ServicesLevelsPriceRepository = servicesLevelsPriceRepository;
        }
        public async Task<int> Execute(Action action)
        {
            using (BeginTransaction())
            {
                try
                {
                    action();

                    var affectedRows = await SaveChangesAsync();
                    await CommitTransactionAsync();
                    return affectedRows;
                }
                catch
                {
                    await RollbackTransactionAsync();
                    throw;
                }
            }
        }

        public async Task<int> ExecuteAsync(Func<Task> action)
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    await action();

                    var affectedRows = await SaveChangesAsync();
                    await transaction.CommitAsync();
                    return affectedRows;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }



        public IDbContextTransaction BeginTransaction()
        {
            return _databaseContext.Database.BeginTransaction();
        }

        public Task CommitTransactionAsync()
        {
            return _databaseContext.Database.CommitTransactionAsync();
        }

        public Task RollbackTransactionAsync()
        {
            return _databaseContext.Database.RollbackTransactionAsync();
        }

        public int SaveChanges()
        {
            return _databaseContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return _databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}
