using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRunner.Domain.Entities;

namespace TRunner.Application.Interfaces.Repositories
{
    public interface IWorkoutSummaryRepository
    {
        Task<int> CreateWorkoutSummary(WorkoutSummary workoutSummary);
    }
}
