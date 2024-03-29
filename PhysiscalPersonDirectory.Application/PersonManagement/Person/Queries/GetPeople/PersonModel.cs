﻿using PhysiscalPersonDirectory.Application.Shared.Mapper;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Application.PersonManagement.Person.Queries.GetPeople
{
    public class PersonModel : MapFrom<Domain.Entities.PersonAggregate.Person>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType Gender { get; set; }
    }
}
