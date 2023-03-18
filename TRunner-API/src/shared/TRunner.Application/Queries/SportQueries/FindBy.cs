using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;

namespace TRunner.Application.Queries.SportQueries
{
    public class FindBy
    {
        public record Query(Expression<Func<Sport, bool>> predicate) : IRequest<IQueryable<Sport>>;

        internal class Handler : IRequestHandler<Query, IQueryable<Sport>>
        {
            private readonly ISportsRepository _sportsRepository;

            public Handler(ISportsRepository sportsRepository)
            {
                _sportsRepository = sportsRepository;
            }
            public Task<IQueryable<Sport>> Handle(Query query, CancellationToken cancellationToken)
            {
                var result = _sportsRepository.FindBy(query.predicate);

                return Task.FromResult(result);
            }
        }
    }
}
