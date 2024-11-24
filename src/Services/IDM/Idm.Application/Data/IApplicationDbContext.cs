namespace Idm.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<TargetSystem> TargetSystems { get; }

        DbSet<TargetSystemDetail> TargetSystemDetails { get; }
        DbSet<Request> Requests { get; }
        DbSet<RequestDetail> RequestDetails { get; }

        DbSet<RequestItem> RequestItems { get; }

        DbSet<RequestUser> RequestUsers { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
