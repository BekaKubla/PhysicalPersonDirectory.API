using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
