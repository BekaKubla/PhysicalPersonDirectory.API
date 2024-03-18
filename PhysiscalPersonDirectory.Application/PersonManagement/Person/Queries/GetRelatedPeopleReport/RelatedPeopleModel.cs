using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetRelatedPeopleReport
{
    public class RelatedPeopleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<RelationshipModel> Relateds { get; set; } = [];
    }

    public class RelationshipModel
    {
        public ContactType ContactType { get; set; }
        public int Count { get; set; }
    }
}
