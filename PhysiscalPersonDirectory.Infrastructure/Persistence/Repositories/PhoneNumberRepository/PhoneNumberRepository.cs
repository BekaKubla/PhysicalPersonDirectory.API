using PhysiscalPersonDirectory.Domain.Entities.PhoneNumberAggregate;
using PhysiscalPersonDirectory.Domain.Repositories.PhoneNumberRepository;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Context;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.Base;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.PhoneNumberRepository
{
    public class PhoneNumberRepository : GenericRepository<PhoneNumber, PersonDbContext>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(PersonDbContext context)
            : base(context)
        {

        }
    }
}
