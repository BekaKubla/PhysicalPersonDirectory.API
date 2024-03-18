using AutoMapper;
using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;
using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPersonDetails
{
    public class PersonDetailsModel : MapFrom<Domain.Entities.PersonAggregate.Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public GenderType Gender { get; set; }
        public byte[] File { get; set; }
        public IEnumerable<PhoneModel> PhoneNumbers { get; set; }
        public IEnumerable<RelatedPersonModel> Relationship { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PersonAggregate.Person, PersonDetailsModel>()
                .ForMember(x => x.City, m => m.MapFrom(t => t.City.Name));
        }
    }


    public class PhoneModel : MapFrom<PhoneNumber>
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }

    public class RelatedPersonModel : MapFrom<RelationPerson>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? City { get; set; }
        public GenderType Gender { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<RelationPerson, RelatedPersonModel>()
                .ForMember(x => x.Id, m => m.MapFrom(t => t.RelatedPerson.Id))
                .ForMember(x => x.Name, m => m.MapFrom(t => t.RelatedPerson.Name))
                .ForMember(x => x.LastName, m => m.MapFrom(t => t.RelatedPerson.Lastname))
                .ForMember(x => x.PersonalNumber, m => m.MapFrom(t => t.RelatedPerson.PersonalNumber))
                .ForMember(x => x.BirthDate, m => m.MapFrom(t => t.RelatedPerson.BirthDate))
                .ForMember(x => x.City, m => m.MapFrom(t => t.RelatedPerson.City.Name))
                .ForMember(x => x.Gender, m => m.MapFrom(t => t.RelatedPerson.Gender));
        }
    }
}
