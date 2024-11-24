namespace Idm.Infrastructure.Data.Configurations
{
    public class RequestUserConfiguration : IEntityTypeConfiguration<RequestUser>
    {
        public void Configure(EntityTypeBuilder<RequestUser> builder)
        {
            builder.HasKey(ru => ru.Id);


            builder.Property(ru => ru.Id).HasConversion(
                            requestUserId => requestUserId.Value,
                            dbId => RequestUserId.Of(dbId));

            builder.Property(ru => ru.ValidFrom).IsRequired();

        }
    }
}
