using Microsoft.EntityFrameworkCore;
using PhysiscalPersonDirectory.Domain.Entities.CityAggregate;
using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;
using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Context
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<RelationPerson> RelationPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);

            #region City Seed Data
            modelBuilder.Entity<City>().HasData(
                City.CreateForSeedData(1, "Kutaisi"),
                City.CreateForSeedData(2, "Tbilisi"),
                City.CreateForSeedData(3, "Batumi"));
            #endregion

            #region Person Seed Data
            modelBuilder.Entity<Person>().HasData(
                Person.CreatePersonForSeedData(1, "Oliver", "Solis", Domain.Enum.GenderType.Female, "60001138372", new DateTime(1999, 04, 29), string.Empty),
                Person.CreatePersonForSeedData(2, "Joan", "Rodriguez", Domain.Enum.GenderType.Male, "60001138373", new DateTime(1999, 03, 29), string.Empty));
            #endregion

            #region Person Relation Seed Data
            modelBuilder.Entity<RelationPerson>().HasData(
                RelationPerson.CreateRelationPersonForSeedData(1, 1, 2, Domain.Enum.ContactType.Collegue));
            #endregion
        }
    }
}
