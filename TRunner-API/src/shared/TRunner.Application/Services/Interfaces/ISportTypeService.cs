using TRunner.Domain.Entities;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Services.Interfaces
{
    public interface ISportTypeService
    {
        Task<IEnumerable<SportTypesResponse>> GetAllSportTypes();
    }
}