using System.Reflection;

namespace Idm.Infrastructure.Data
{
    public class IDMDbContext : DbContext, IApplicationDbContext
    {

        public IDMDbContext(DbContextOptions<IDMDbContext> options) : base(options) 
        {
             
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<TargetSystem> TargetSystems => Set<TargetSystem>();

        public DbSet<TargetSystemDetail> TargetSystemDetails => Set<TargetSystemDetail>();

        public DbSet<Request> Requests => Set<Request>();

        public DbSet<RequestDetail> RequestDetails => Set<RequestDetail>();

        public DbSet<RequestItem> RequestItems => Set<RequestItem>();

        public DbSet<RequestUser> RequestUsers => Set<RequestUser>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
