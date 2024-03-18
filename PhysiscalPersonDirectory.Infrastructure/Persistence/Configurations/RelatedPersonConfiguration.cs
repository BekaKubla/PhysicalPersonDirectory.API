using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Configurations
{
    public class RelatedPersonConfiguration : IEntityTypeConfiguration<RelationPerson>
    {
        public void Configure(EntityTypeBuilder<RelationPerson> builder)
        {
            builder.ToTable("RelationPeople", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Person)
                   .WithMany(a => a.Relationship)
                   .HasForeignKey(a => a.PersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RelatedPerson)
                   .WithMany(a => a.RelatedTo)
                   .HasForeignKey(a => a.RelatedPersonId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
