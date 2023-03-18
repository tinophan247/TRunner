using TRunner.Application.Interfaces.Repositories;
using MediatR;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Response;
using TRunner.Domain.Models.Request;

namespace TRunner.Application.Queries
{
    public class GetSports
    {
        public record Query(
            PaginationRequest request
            ) : IRequest<TRunnerPageResults<SportResponse>>;

        //internal class Validator : AbstractValidator<Query>
        //{
        //    public Validator()
        //    {
        //        RuleFor(x => x.request.PageIndex)
        //            .GreaterThan(0).WithMessage("Page index is greater than 0")
        //            .NotEmpty().WithMessage("Page index is required");
        //        RuleFor(x => x.request.PageSize)
        //            .GreaterThan(0).WithMessage("Page size is greater than 0")
        //            .NotEmpty().WithMessage("Page size is required");
        //    }
        //}

        internal class Handler : IRequestHandler<Query, TRunnerPageResults<SportResponse>>
        {
            private readonly ISportsRepository _sportsRepository;

            public Handler(ISportsRepository sportsRepository)
            {
                _sportsRepository = sportsRepository;
            }

            public async Task<TRunnerPageResults<SportResponse>> Handle(Query query, CancellationToken cancellationToken)
            {
                string filter = string.IsNullOrEmpty(query.request.Keyword) ? "" : $"WHERE SportName LIKE %{query.request.PageIndex}%";
                string sort = "SportName ASC";
                var result = await _sportsRepository.GetSports(query.request.PageIndex, query.request.PageSize, filter, sort);

                return TRunnerPagingUtility.CreatePagedResultsQuery(
                    result.Sports,
                    query.request.PageIndex,
                    query.request.PageSize,
                    result.TotalRow);
            }
        }
    }
}
