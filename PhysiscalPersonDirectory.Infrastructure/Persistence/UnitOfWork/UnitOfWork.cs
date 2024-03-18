using PhysiscalPersonDirectory.Domain.Repositories.CityRepository;
using PhysiscalPersonDirectory.Domain.Repositories.PersonRepository;
using PhysiscalPersonDirectory.Domain.Repositories.PhoneNumberRepository;
using PhysiscalPersonDirectory.Domain.SeedWork;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Context;

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDbContext _context;

        public ICityRepository CityRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IPhoneNumberRepository PhoneNumberRepository { get; }

        public UnitOfWork(
            PersonDbContext context,
            ICityRepository cityRepository,
            IPersonRepository personRepository,
            IPhoneNumberRepository phoneNumberRepository)
        {
            _context = context;
            CityRepository = cityRepository;
            PersonRepository = personRepository;
            PhoneNumberRepository = phoneNumberRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
