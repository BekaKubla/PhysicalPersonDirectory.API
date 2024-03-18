using PhysiscalPersonDirectory.Domain.Entities.Base;
using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;
using PhysiscalPersonDirectory.Domain.Enum;

namespace PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate
{
    public class PhoneNumber : BaseEntity<int>
    {
        protected PhoneNumber()
        {

        }
        public PhoneNumber(string? number, PhoneNumberType type)
        {
            Number = number;
            Type = type;
        }

        public string? Number { get; private set; }
        public PhoneNumberType Type { get; private set; }
        public int PersonId { get; private set; }

        public virtual Person Person { get; private set; }

        public static PhoneNumber Create(string? number, PhoneNumberType type) => new(number, type);
        public void Update(string number, PhoneNumberType phoneNumberType)
        {
            if (Number != number)
                Number = number;

            if (phoneNumberType != Type)
                Type = phoneNumberType;
        }

    }
}
