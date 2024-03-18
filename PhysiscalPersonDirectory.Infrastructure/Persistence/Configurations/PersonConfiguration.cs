using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true)
                .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Lastname);
            builder.HasIndex(x => x.PersonalNumber);

            builder.HasOne(x => x.City)
                .WithMany(y => y.Persons)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PhoneNumbers)
                .WithOne(y => y.Person)
                .HasForeignKey(y => y.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
