using TRunner.Application.Interfaces.Repositories;
using MediatR;
using System.Linq.Expressions;
using TRunner.Domain.Entities;

namespace TRunner.Application.Queries.UserQueries;

public class FindBy
{
    public record Query(Expression<Func<User, bool>> predicate) : IRequest<IQueryable<User>>;

    internal class Handler : IRequestHandler<Query, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(Query query, CancellationToken cancellationToken)
        {
            var result = _userRepository.FindBy(query.predicate);

            return Task.FromResult(result);
        }
    }
}
