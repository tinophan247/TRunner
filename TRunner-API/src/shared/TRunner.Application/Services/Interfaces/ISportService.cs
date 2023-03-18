using TRunner.Domain.Entities;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services.Interfaces
{
    public interface ISportService
    {
        Task<TRunnerPageResults<SportResponse>> GetListOfSportsWithPaging(PaginationRequest request);

        Task<SportResponse> CreateSport(CreateSportRequest request);

        Task<int> UpdateSport(int Id, SportRequestModel request);
    }
}
