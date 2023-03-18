using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;
using TRunner.Infrastructure.ConnectionStrings;

namespace TRunner.Infrastructure.Repositories
{
    public class WorkoutSummaryRepository : IWorkoutSummaryRepository
    {
        #region Private Members
        private readonly TRunnerDbContext _trunnerDbContext;
        #endregion

        #region Constructors
        public WorkoutSummaryRepository(TRunnerDbContext trunnerDbContext)
        {
            _trunnerDbContext = trunnerDbContext;
        }
        #endregion
        public async Task<int> CreateWorkoutSummary(WorkoutSummary workoutSummary)
        {
           _trunnerDbContext.WorkoutSummaries.Add(workoutSummary);
           return await _trunnerDbContext.SaveChangesAsync();
        }
    }
}
