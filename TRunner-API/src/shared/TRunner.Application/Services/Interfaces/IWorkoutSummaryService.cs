using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services.Interfaces
{
    public interface IWorkoutSummaryService
    {
        Task<BaseResponseModel> CreateWorkoutSummary(CreateWorkoutSummaryRequest request);
    }
}
