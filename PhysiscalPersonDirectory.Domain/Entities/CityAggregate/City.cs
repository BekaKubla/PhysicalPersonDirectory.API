using PhysiscalPersonDirectory.Domain.Entities.Base;
using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;

namespace PhysiscalPersonDirectory.Domain.Entities.CityAggregate
{
    public class City : BaseEntity<int>
    {
        protected City()
        {

        }
        private City(int id, string name)
        {
            Id = id;
            Name = name;
        }
        private City(string? name)
        {
            Name = name;
        }

        public string? Name { get; private set; }


        public virtual ICollection<Person> Persons { get; private set; } = [];

        public static City Create(string? name) => new(name);
        public static City CreateForSeedData(int id, string name) => new(id, name);
        public void Update(string? name) => Name = name;
    }
}
