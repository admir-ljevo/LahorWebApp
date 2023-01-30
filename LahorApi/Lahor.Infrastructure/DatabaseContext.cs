using Lahor.Core.Entities;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lahor.Infrastructure
{
    public partial class DatabaseContext: IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersServicesLevels> OrdersServicesLevels { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TypeOfService> TypeOfServices { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<ServicesLevelsPrice> ServicesLevelsPrice { get; set; }
        public DbSet<LevelOfServiceExecution> LevelOfServiceExecution { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityTypeConfiguration<>).Assembly);

            //SeedData(modelBuilder);
        }
    }
}
