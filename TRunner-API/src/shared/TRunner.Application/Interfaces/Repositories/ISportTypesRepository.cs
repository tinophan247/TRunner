using TRunner.Domain.Entities;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Interfaces.Repositories
{
    public interface ISportTypesRepository
    {
        IQueryable<SportType> GetAllSportTypes();
    }
}