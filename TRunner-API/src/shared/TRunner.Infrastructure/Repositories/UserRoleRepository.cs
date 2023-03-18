using System.Data;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Infrastructure.ConnectionStrings;
using Microsoft.Extensions.Logging;
using TRunner.Domain.Entities;
using System.Linq.Expressions;

namespace TRunner.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    #region Private Members
    private readonly TRunnerDbContext _trunnerDbContext;

    private ILogger _logger;
    #endregion

    #region Constructors
    public UserRoleRepository(TRunnerDbContext trunnerDbContext, ILoggerFactory loggerFactory)
    {
        _trunnerDbContext = trunnerDbContext;
        _logger = loggerFactory.CreateLogger(nameof(SportsRepository));
    }
    #endregion

    #region Functions
    public IQueryable<UserRole> FindBy(Expression<Func<UserRole, bool>> predicate)
    {
        return _trunnerDbContext.UserRoles.Where(predicate);
    }
    #endregion
}
