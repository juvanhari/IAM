namespace Idm.Infrastructure.Data.Configurations
{
    public class TargetSystemDetailConfiguration : IEntityTypeConfiguration<TargetSystemDetail>
    {
        public void Configure(EntityTypeBuilder<TargetSystemDetail> builder)
        {
            builder.HasKey(td => td.Id);

            builder.Property(td => td.Id).HasConversion(
                                       targetDetailId => targetDetailId.Value,
                                       dbId => TargetSystemDetailId.Of(dbId));


            builder.Property(oi => oi.Code).IsRequired();

            builder.Property(oi => oi.Value).IsRequired();
        }
    }
}
