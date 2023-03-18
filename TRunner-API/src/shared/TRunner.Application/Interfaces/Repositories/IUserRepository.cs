using System.Linq.Expressions;
using TRunner.Domain.Entities;
using TRunner.Domain.Models.Response;

namespace TRunner.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> FindBy(Expression<Func<User, bool>> predicate);
        Task<ListUsersResponse> GetUsers(int pageIndex, int pageSize, string filter, string orderby);
        Task<int> CreateUser(User user);
        Task<int> UpdateUser(User user);
    }
}
