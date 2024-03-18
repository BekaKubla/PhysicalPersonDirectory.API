using PhysiscalPersonDirectory.Application.Shared.Specification;
using PhysiscalPersonDirectory.Application.Shared.Utilities;
using System.Linq.Expressions;

namespace PhysiscalPersonDirectory.Application.CityManagement.City.Queries.GetCities
{
    public class CitySpecification : Specification<Domain.Entities.CityAggregate.City>
    {
        private Expression<Func<Domain.Entities.CityAggregate.City, bool>> BaseExpression { get; set; } = u => u.IsActive;

        private readonly GetCityQuery _filter;

        public CitySpecification(GetCityQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Domain.Entities.CityAggregate.City, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (!string.IsNullOrWhiteSpace(_filter.Name))
            {
                result = result.And(x => x.Name.Contains(_filter.Name));
            }

            return result;
        }
    }
}
