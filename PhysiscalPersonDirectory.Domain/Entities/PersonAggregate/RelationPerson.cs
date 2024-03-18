using PhysiscalPersonDirectory.Domain.Entities.Base;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Domain.Entities.PersonAggregate
{
    public class RelationPerson : BaseEntity<int>
    {
        protected RelationPerson()
        {

        }
        private RelationPerson(Person relatedPerson, ContactType contactType)
        {
            RelatedPerson = relatedPerson;
            ContactType = contactType;
        }

        private RelationPerson(int id, int personId, int relatedPersonId, ContactType contactType)
        {
            Id = id;
            PersonId = personId;
            RelatedPersonId = relatedPersonId;
            ContactType = contactType;
        }

        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public ContactType ContactType { get; private set; }

        public virtual Person Person { get; set; }
        public virtual Person RelatedPerson { get; set; }

        public static RelationPerson Create(Person relatedPerson, ContactType contactType) => new(relatedPerson, contactType);
        public static RelationPerson CreateRelationPersonForSeedData(int id, int personId, int relatedPersonId, ContactType contactType) =>
            new(id, personId, relatedPersonId, contactType);
        public void Update(ContactType contactType) => ContactType = contactType;
    }
}
