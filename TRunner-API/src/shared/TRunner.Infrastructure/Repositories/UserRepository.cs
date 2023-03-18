using System.Data;
using Dapper;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Response;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Infrastructure.ConnectionStrings;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using TRunner.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TRunner.Core.Common.Exceptions;
using System.Net;
using TRunner.Core.Resources;

namespace TRunner.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    #region Private Members
    private readonly TRunnerDbContext _trunnerDbContext;

    private ILogger _logger;
    #endregion

    #region Constructors
    public UserRepository(TRunnerDbContext trunnerDbContext, ILoggerFactory loggerFactory)
    {
        _trunnerDbContext = trunnerDbContext;
        _logger = loggerFactory.CreateLogger(nameof(SportsRepository));
    }
    #endregion

    #region Functions
    public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
    {
        return _trunnerDbContext.Users.Where(predicate);
    }

    public async Task<int> CreateUser(User user)
    {

        _trunnerDbContext.Users.Add(user);
        return await _trunnerDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateUser(User user)
    {
        _trunnerDbContext.Entry(user).State = EntityState.Modified;
        _trunnerDbContext.Entry(user).Property(x => x.CreatedDate).IsModified = false;
        return await _trunnerDbContext.SaveChangesAsync();
    }

    public async Task<ListUsersResponse> GetUsers(int pageIndex, int pageSize, string filter, string orderby)
    {
        try
        {
            using var connection = new MySqlConnection() { ConnectionString = "server=localhost; user=root; database=trunnerdev; password=Tuananh@1811; port=3306; Allow Zero Datetime=True" };
            var sql = $@"SELECT 
                                    SQL_CALC_FOUND_ROWS             
                                    u.UserId, 
                                    u.UserUUId, 
                                    u.Email, 
                                    ur.RoleName as UserRole,
                                    u.CreatedBy, 
                                    u.UpdatedBy, 
                                    u.CreatedDate, 
                                    u.UpdatedDate, 
                                    u.IsActive, 
                                    u.IsDeleted
                              FROM User as u
                              INNER JOIN UserRole as ur on u.UserRoleId = ur.UserRoleId
                              {filter}
                              ORDER BY {orderby}
                              LIMIT @limit
                              OFFSET @offset;
                              SELECT FOUND_ROWS();";

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@offset", (pageIndex - 1) * pageSize);
            queryParameters.Add("@limit", pageSize);

            var query = await connection.QueryMultipleAsync(sql, queryParameters, commandType: CommandType.Text);

            var users = (await query.ReadAsync<UserResponse>()).ToList();
            var totalRow = await query.ReadSingleOrDefaultAsync<long>();

            return new ListUsersResponse
            {
                Users = users,
                TotalRow = (int)totalRow
            };
        }
        catch (Exception ex)
        {
            var error = $"GetUsers - {Helpers.BuildErrorMessage(ex)}";
            _logger.LogError(error);
            throw new Exception(error);
        }
    }
    #endregion
}
