using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq.Expressions;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Request;
using TRunner.Domain.Models.Response;
using TRunner.Infrastructure.ConnectionStrings;

namespace TRunner.Infrastructure.Repositories;

public class SportsRepository : ISportsRepository
{
    #region Private Members
    private readonly TRunnerDbContext _trunnerDbContext;
    private ILogger _logger;
    #endregion

    #region Constructors
    public SportsRepository(TRunnerDbContext trunnerDbContext, ILoggerFactory loggerFactory)
    {
        _trunnerDbContext = trunnerDbContext;
        _logger = loggerFactory.CreateLogger(nameof(SportsRepository));
    }
    #endregion

    public IQueryable<Sport> FindBy(Expression<Func<Sport, bool>> predicate)
    {
        return _trunnerDbContext.Sports.Where(predicate);
    }

    public async Task<int> CreateSport(Sport sport)
    {
        var result = _trunnerDbContext.Sports.Add(sport);
        return await _trunnerDbContext.SaveChangesAsync();
    }

    public async Task<ListSportsResponse> GetSports(int pageIndex, int pageSize, string filter, string orderby)
    {
        try
        {
            using (var connection = new MySqlConnection() { ConnectionString = "server=localhost; user=root; database=trunnerdev; password=Tuananh@1811; port=3306; Allow Zero Datetime=True" })
            {
                var sql = $@"SELECT 
                                    SQL_CALC_FOUND_ROWS             
                                    SportId, 
                                    SportImage, 
                                    SportName, 
                                    SportType, 
                                    CreatedBy, 
                                    UpdatedBy, 
                                    CreatedDate, 
                                    UpdatedDate, 
                                    IsActive, 
                                    IsDeleted
                              FROM Sport
                              {filter}
                              ORDER BY {orderby}
                              LIMIT @limit
                              OFFSET @offset;
                              SELECT FOUND_ROWS();";

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@offset", (pageIndex - 1) * pageSize);
                queryParameters.Add("@limit", pageSize);

                var query = await connection.QueryMultipleAsync(sql, queryParameters, commandType: CommandType.Text);

                var sports = (await query.ReadAsync<SportResponse>()).ToList();
                var totalRow = await query.ReadSingleOrDefaultAsync<long>();

                return new ListSportsResponse
                {
                    Sports = sports,
                    TotalRow = (int)totalRow
                };
            }
        }
        catch (Exception ex)
        {
            var error = $"GetSports - {Helpers.BuildErrorMessage(ex)}";
            _logger.LogError(error);
            throw new Exception(error);
        }
    }
    public async Task<int> UpdateSport(int sportId, SportRequestModel request)
    {
        try
        {
            using (var connection = new MySqlConnection() { ConnectionString = "server=localhost; user=root; database=trunnverdev; password=Tuananh@1811; port=3306; Allow Zero Datetime=True" })
            {
                var query = $@"SELECT SportName FROM Sports WHERE SportId = {sportId}";

                var sportNameById = await connection.QueryFirstOrDefaultAsync<string>(query);

                //var sportName = await CheckSportNameIsUnique(request.SportName);
                //if (sportName != null && sportNameById == request.SportName)
                //{
                //    return 0;
                //}

                var sql = @"UPDATE Sports
                            SET SportImage = @sportImage, 
                                SportName = @sportName, 
                                SportType = @sportType,
                                UpdatedBy = @updatedBy,
                                UpdatedDate = @updatedDate,
                                IsActive = @isActive
                            WHERE SportId = @sportId;";

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@sportImage", request.SportImage);
                queryParameters.Add("@sportName", request.SportName);
                queryParameters.Add("@sportType", request.SportType);
                queryParameters.Add("@isActive", request.IsActive);
                queryParameters.Add("@updatedBy", Guid.NewGuid().ToString());
                queryParameters.Add("@updatedDate", DateTime.Now);
                queryParameters.Add("@sportId", sportId);

                var result = await connection.ExecuteAsync(sql, queryParameters);
                return result;
            }
        }
        catch (Exception ex)
        {
            var error = $"UpdateSport - {Helpers.BuildErrorMessage(ex)}";
            return -1;
        }
    }
}
