namespace Idm.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            // Add services to the container.
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            services.AddDbContext<IDMDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IApplicationDbContext, IDMDbContext>();

            return services;
        }

    }
}
