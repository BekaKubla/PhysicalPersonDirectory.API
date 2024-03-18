using PhysiscalPersonDirectory.Domain.Entities.PersonAggregate;
using PhysiscalPersonDirectory.Domain.Repositories.PersonRepository;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Context;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.Base;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.PersonRepository
{
    public class PersonRepository : GenericRepository<Person, PersonDbContext>, IPersonRepository
    {
        public PersonRepository(PersonDbContext context)
            : base(context)
        {

        }

    }
}
