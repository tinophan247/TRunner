using FluentValidation;
using MediatR;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Queries
{
    public class GetGroups
    {
        public record Query(
            int pageSize,
            int pageIndex
            ) : IRequest<TRunnerPageResults<GroupsResponse>>;

        internal class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.pageIndex)
                    .GreaterThan(0).WithMessage("Page index is greater than 0")
                    .NotEmpty().WithMessage("Page index must not empty")
                    .NotNull().WithMessage("Page index is required");
                RuleFor(x => x.pageSize)
                    .GreaterThan(0).WithMessage("Page size is greater than 0")
                    .NotEmpty().WithMessage("Page size must not empty")
                    .NotNull().WithMessage("Page size is required");
            }
        }

        internal class Handler : IRequestHandler<Query, TRunnerPageResults<GroupsResponse>>
        {
            private readonly IGroupRepository _groupRepository;

            public Handler(IGroupRepository groupRepository)
            {
                _groupRepository = groupRepository;
            }

            public async Task<TRunnerPageResults<GroupsResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _groupRepository.GetGroups(request.pageSize, request.pageIndex);

                return TRunnerPagingUtility.CreatePagedResultsQuery(
                    result.Groups,
                    request.pageIndex,
                    request.pageSize,
                    result.TotalRow);
            }
        }
    }
}
