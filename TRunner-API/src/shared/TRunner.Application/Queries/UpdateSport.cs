using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Models.Request;

namespace TRunner.Application.Queries
{
    public class UpdateSport
    {
        public record Query(int sportId,
            SportRequestModel request
            ) : IRequest<int>;
        internal class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.sportId)
                    .GreaterThan(0).WithMessage("SportId is greater than 0")
                    .NotNull().WithMessage("SportId is required");
                RuleFor(x => x.request.SportName)
                     .NotEmpty().WithMessage("Sport name is required");
                RuleFor(x => x.request.SportType)
                     .NotEmpty().WithMessage("Sport type is required");
                RuleFor(x => x.request.IsActive)
                    .NotEmpty().WithMessage("Active is required");
            }
        }

        internal class Handler : IRequestHandler<Query, int>
        {
            private readonly ISportsRepository _sportsRepository;

            public Handler(ISportsRepository sportsRepository)
            {
                _sportsRepository = sportsRepository;
            }

            public async Task<int> Handle(Query query, CancellationToken cancellationToken)
            {
                var result = await _sportsRepository.UpdateSport(query.sportId, query.request);

                return result;
            }
        }
    }
}
