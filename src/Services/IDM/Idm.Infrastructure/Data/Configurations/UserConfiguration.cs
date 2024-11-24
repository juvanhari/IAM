namespace Idm.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                            userId => userId.Value,
                            dbId => UserId.Of(dbId));

            builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();

            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Department).HasMaxLength(100).IsRequired();
        }
    }
}
