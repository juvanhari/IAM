


namespace Idm.Infrastructure.Data.Configurations
{
    public class TargetSystemConfiguration : IEntityTypeConfiguration<TargetSystem>
    {
        public void Configure(EntityTypeBuilder<TargetSystem> builder)
        {
            builder.HasKey(t => t.Id);


            builder.Property(t => t.Id).HasConversion(
                            targetSystemId => targetSystemId.Value,
                            dbId => TargetSystemId.Of(dbId));


            builder.HasMany(t => t.TargetSystemConfigurationDetails)
                .WithOne()
                .HasForeignKey(oi => oi.TargetSystemId);

            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();

            builder.Property(t => t.ApplicationCode).HasMaxLength(100).IsRequired();


        }
    }
}
