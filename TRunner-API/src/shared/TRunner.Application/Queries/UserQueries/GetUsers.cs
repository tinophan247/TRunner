using TRunner.Application.Interfaces.Repositories;
using MediatR;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Response;
using TRunner.Domain.Models.Request;

namespace TRunner.Application.Queries.UserQueries;

public class GetUsers
{
    public record Query(
        PaginationRequest request
        ) : IRequest<TRunnerPageResults<UserResponse>>;

    internal class Handler : IRequestHandler<Query, TRunnerPageResults<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<TRunnerPageResults<UserResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
            string filter = string.IsNullOrEmpty(query.request.Keyword) ? "" : $"WHERE u.Email LIKE %{query.request.Keyword}%";
            string sort = "u.Email ASC";
            var result = await _userRepository.GetUsers(query.request.PageIndex, query.request.PageSize, filter, sort);

            return TRunnerPagingUtility.CreatePagedResultsQuery(
                result.Users,
                query.request.PageIndex,
                query.request.PageSize,
                result.TotalRow);
        }
    }
}
