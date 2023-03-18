using TRunner.Application.Interfaces.Repositories;
using MediatR;
using System.Linq.Expressions;
using TRunner.Domain.Entities;

namespace TRunner.Application.Queries.UserRoleQueries;

public class FindBy
{
    public record Query(Expression<Func<UserRole, bool>> predicate) : IRequest<IQueryable<UserRole>>;

    internal class Handler : IRequestHandler<Query, IQueryable<UserRole>>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public Handler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public Task<IQueryable<UserRole>> Handle(Query query, CancellationToken cancellationToken)
        {
            var result = _userRoleRepository.FindBy(query.predicate);

            return Task.FromResult(result);
        }
    }
}
