using System.Linq.Expressions;
using TRunner.Domain.Entities;

namespace TRunner.Application.Interfaces.Repositories
{
    public interface IUserRoleRepository
    {
        IQueryable<UserRole> FindBy(Expression<Func<UserRole, bool>> predicate);
    }
}
