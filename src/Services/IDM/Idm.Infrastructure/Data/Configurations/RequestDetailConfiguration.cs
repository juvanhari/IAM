


namespace Idm.Infrastructure.Data.Configurations
{
    public class RequestDetailConfiguration : IEntityTypeConfiguration<RequestDetail>
    {
        public void Configure(EntityTypeBuilder<RequestDetail> builder)
        {
            builder.HasKey(r => r.Id);


            builder.Property(r => r.Id).HasConversion(
                            requestdetailId => requestdetailId.Value,
                            dbId => RequestDetailId.Of(dbId));


            builder.HasMany(r => r.RequestItems)
                .WithOne()
                .HasForeignKey(oi => oi.RequestDetailId);

            builder.HasMany(r => r.RequestUsers)
               .WithOne()
               .HasForeignKey(oi => oi.RequestDetailId);

            builder.Property(r => r.TargetSystemId).HasConversion(
                           targetSystemId => targetSystemId.Value,
                           dbId => TargetSystemId.Of(dbId));

            builder.Property(t => t.TargetSystemId).IsRequired();

            builder.Property(o => o.AdhocActionType)
             .HasDefaultValue(AdhocActionType.None)
             .HasConversion(
                 s => s.ToString(),
                 dbStatus => (AdhocActionType)Enum.Parse(typeof(AdhocActionType), dbStatus));
        }
    }
}
