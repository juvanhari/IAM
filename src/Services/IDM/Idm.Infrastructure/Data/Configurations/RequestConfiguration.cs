
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Idm.Infrastructure.Data.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);


            builder.Property(r => r.Id).HasConversion(
                            requestId => requestId.Value,
                            dbId => RequestId.Of(dbId));


            builder.HasMany(r => r.RequestDetails)
                .WithOne()
                .HasForeignKey(oi => oi.RequestId);

            builder.Property(t => t.RequestorName).HasMaxLength(100).IsRequired();

            builder.Property(o => o.RequestStatus)
             .HasDefaultValue(RequestStatus.Submitted)
             .HasConversion(
                 s => s.ToString(),
                 dbStatus => (RequestStatus)Enum.Parse(typeof(RequestStatus), dbStatus));
        }
    }
}
