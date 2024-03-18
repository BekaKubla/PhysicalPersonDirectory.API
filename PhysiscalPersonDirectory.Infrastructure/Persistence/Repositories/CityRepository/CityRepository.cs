using PhysiscalPersonDirectory.Domain.Entities.CityAggregate;
using PhysiscalPersonDirectory.Domain.Repositories.CityRepository;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Context;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.Base;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.CityRepository
{
    public class CityRepository : GenericRepository<City, PersonDbContext>, ICityRepository
    {
        public CityRepository(PersonDbContext context)
            : base(context)
        {

        }
    }
}
