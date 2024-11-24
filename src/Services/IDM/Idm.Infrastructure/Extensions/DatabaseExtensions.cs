namespace Idm.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task IntialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<IDMDbContext>();

            dbContext.Database.MigrateAsync().GetAwaiter().GetResult();
            await SeedAsync(dbContext);

        }
        private static async Task SeedAsync(IDMDbContext context)
        {
            await SeedUserAsync(context);
            await SeedTargetSystemsWithDetailsAsync(context);
        }

        private static async Task SeedUserAsync(IDMDbContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                await context.Users.AddRangeAsync(InitialData.Users);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedTargetSystemsWithDetailsAsync(IDMDbContext context)
        {
            if (!await context.TargetSystems.AnyAsync())
            {
                await context.TargetSystems.AddRangeAsync(InitialData.TargetSystemsWithDetails);
                await context.SaveChangesAsync();
            }
        }
    }
}
