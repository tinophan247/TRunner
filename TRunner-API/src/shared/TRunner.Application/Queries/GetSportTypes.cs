using MediatR;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;

namespace TRunner.Application.Queries
{
    public class GetSportTypes
    {
        public record Query() : IRequest<IQueryable<SportType>>;

        internal class Handler : IRequestHandler<Query, IQueryable<SportType>>
        {
            private readonly ISportTypesRepository _sportTypesRepository;

            public Handler(ISportTypesRepository sportTypesRepository)
            {
                _sportTypesRepository = sportTypesRepository;
            }

            public async Task<IQueryable<SportType>> Handle(Query query, CancellationToken cancellationToken)
            {
                var result = _sportTypesRepository.GetAllSportTypes();

                return await Task.FromResult(result);
            }
        }
    }
}