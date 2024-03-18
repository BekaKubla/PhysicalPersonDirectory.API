using AutoMapper;

namespace PhysiscalPersonDirectory.Application.Shared.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
