using MediatR;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;

namespace TRunner.Application.Commands.WorkoutSummaryCommands
{
    public class CreateWorkoutSummary
    {
        public record Command(
        WorkoutSummary data
        ) : IRequest<int>;

        internal class Handler : IRequestHandler<Command, int>
        {
            private IWorkoutSummaryRepository _workoutSummaryRepository;

            public Handler(IWorkoutSummaryRepository workoutSummaryRepository)
            {
                _workoutSummaryRepository = workoutSummaryRepository;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _workoutSummaryRepository.CreateWorkoutSummary(request.data);

                return result;
            }
        }
    }
}
