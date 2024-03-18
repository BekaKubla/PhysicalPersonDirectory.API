using PhysiscalPersonDirectory.Common.Resources;
using PhysiscalPersonDirectory.Common.Shared.Exceptions;
using PhysiscalPersonDirectory.Domain.Entities.Base;
using PhysiscalPersonDirectory.Domain.Entities.CityAggregate;
using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Domain.Entities.PersonAggregate
{
    public class Person : BaseEntity<int>
    {
        protected Person()
        {
            PhoneNumbers = new List<PhoneNumber>();
            Relationship = new List<RelationPerson>();
            RelatedTo = new List<RelationPerson>();
        }

        private Person(int id,
                      string name,
                      string lastname,
                      GenderType gender,
                      string personalNumber,
                      DateTime birthDate,
                      string image)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Gender = gender;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            Image = image;
        }

        private Person(string name,
                      string lastname,
                      GenderType gender,
                      string personalNumber,
                      DateTime birthDate,
                      string image)
        {
            Name = name;
            Lastname = lastname;
            Gender = gender;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            Image = image;
        }

        public string? Name { get; private set; }
        public string? Lastname { get; private set; }
        public GenderType Gender { get; private set; }
        public string? PersonalNumber { get; private set; }
        public DateTime BirthDate { get; set; }
        public string? Image { get; private set; }
        public int? CityId { get; private set; }

        public virtual City? City { get; private set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; private set; }
        public virtual ICollection<RelationPerson> Relationship { get; set; }
        public virtual ICollection<RelationPerson> RelatedTo { get; set; }

        public static Person Create(string name,
                                    string lastname,
                                    GenderType gender,
                                    string personalNumber,
                                    DateTime birthDate,
                                    string image) => new(name, lastname, gender, personalNumber, birthDate, image);

        public static Person CreatePersonForSeedData(int id, string name,
                            string lastname,
                            GenderType gender,
                            string personalNumber,
                            DateTime birthDate,
                            string image) => new(id, name, lastname, gender, personalNumber, birthDate, image);

        public void AssignCity(City? city)
        {
            City = city;
        }
        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (!PhoneNumbers.Any(x => x.Number == phoneNumber.Number && x.IsActive))
                PhoneNumbers.Add(phoneNumber);
        }

        public void Update(string? personalNumber,
                           string? name,
                           string? lastname,
                           GenderType gender,
                           DateTime birthDate,
                           int? cityId)
        {
            if (personalNumber != PersonalNumber)
                PersonalNumber = personalNumber;

            if (name != Name)
                Name = name;

            if (lastname != Lastname)
                Lastname = lastname;

            if (gender != Gender)
                Gender = gender;

            if (birthDate != BirthDate)
                BirthDate = birthDate;

            if (cityId.HasValue && cityId != CityId)
                CityId = cityId;
        }

        public void ChangeImage(string? image) => Image = image;

        public void ChangePhoneNumber(int phoneId, string phone, PhoneNumberType phoneNumberType)
        {
            var phoneNumber = PhoneNumbers.FirstOrDefault(x => x.Id == phoneId && x.IsActive);

            if (phoneNumber == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, phoneId);

            phoneNumber.Update(phone, phoneNumberType);
        }

        public void DeletePhoneNumber(int phoneId)
        {
            var phoneNumber = PhoneNumbers.FirstOrDefault(x => x.Id == phoneId && x.IsActive);

            if (phoneNumber == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, phoneId);

            phoneNumber.Delete();
        }

        public void AddRelatedPerson(Person person, ContactType contactType)
        {
            Relationship.Add(RelationPerson.Create(person, contactType));
        }

        public void UpdateRelatedPerson(int personId, ContactType contactType)
        {
            var relatedPerson = Relationship.FirstOrDefault(x => x.Id == personId && x.IsActive);

            if (relatedPerson == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, personId);

            relatedPerson.Update(contactType);
        }

        public void DeleteRelatedPerson(int personId)
        {
            var relatedPerson = Relationship.FirstOrDefault(x => x.Id == personId && x.IsActive);

            if (relatedPerson == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, personId);

            relatedPerson.Delete();
        }
    }
}
