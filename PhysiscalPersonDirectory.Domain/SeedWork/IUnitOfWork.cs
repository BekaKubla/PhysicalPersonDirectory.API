using PhysiscalPersonDirectory.Domain.Repositories.CityRepository;
using PhysiscalPersonDirectory.Domain.Repositories.PersonRepository;
using PhysiscalPersonDirectory.Domain.Repositories.PhoneNumberRepository;
using PhysiscalPersonDirectory.Domain.SeedWork.Base;

namespace PhysiscalPersonDirectory.Domain.SeedWork
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {
        ICityRepository CityRepository { get; }
        IPersonRepository PersonRepository { get; }
        IPhoneNumberRepository  PhoneNumberRepository { get; }
    }
}
