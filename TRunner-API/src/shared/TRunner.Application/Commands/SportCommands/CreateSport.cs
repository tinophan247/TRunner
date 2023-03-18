using MediatR;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;

namespace TRunner.Application.Commands.SportCommands
{
    public class CreateSport
    {
        public record Command(
        Sport data
        ) : IRequest<int>;

        internal class Handler : IRequestHandler<Command, int>
        {
            private readonly ISportsRepository _sportsRepository;

            public Handler(ISportsRepository sportsRepository)
            {
                _sportsRepository = sportsRepository;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _sportsRepository.CreateSport(command.data);

                return result;
            }
        }
    }
}
