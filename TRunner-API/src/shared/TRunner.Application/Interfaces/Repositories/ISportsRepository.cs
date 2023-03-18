using System.Linq.Expressions;
using TRunner.Domain.Entities;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Interfaces.Repositories
{
    public interface ISportsRepository
    {
        IQueryable<Sport> FindBy(Expression<Func<Sport, bool>> predicate);

        Task<ListSportsResponse> GetSports(int pageIndex, int pageSize, string filter, string orderby);

        Task<int> CreateSport(Sport sport);

        Task<int> UpdateSport(int Id, SportRequestModel request);
    }
}
