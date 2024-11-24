

namespace Idm.Infrastructure.Data.Configurations
{
    internal class RequestItemConfiguration : IEntityTypeConfiguration<RequestItem>
    {
        public void Configure(EntityTypeBuilder<RequestItem> builder)
        {
            builder.HasKey(ri => ri.Id);


            builder.Property(ri => ri.Id).HasConversion(
                            requestItemId => requestItemId.Value,
                            dbId => RequestItemId.Of(dbId));

            builder.Property(ri => ri.Code).HasMaxLength(100).IsRequired();

            builder.Property(ri => ri.Value).IsRequired();
        }
    }
}
