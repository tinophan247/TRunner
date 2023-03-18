﻿using Dapper;
using System.Data;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Response;
using TRunner.Infrastructure.Interfaces;

namespace TRunner.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        #region Private Members
        private readonly IDbConnection _connection;
        #endregion

        #region Constructors
        public GroupRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.CreateConnection();
        }

        public GroupRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        #endregion

        public async Task<ListGroupResponse> GetGroups(int pageSize, int pageIndex)
        {
            try
            {
                var sql = @$"SELECT GroupId ,GroupName, Description, Location, Sport, GroupType, CreatedDate, TotalRunner, IsActive
                            FROM Groups
                            ORDER BY GroupName ASC
                            OFFSET @offset ROWS
                            FETCH NEXT @limit ROW ONLY;
                            SELECT COUNT(*) AS TotalRows FROM Groups;";

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@limit", pageSize);
                queryParameters.Add("@offset", (pageIndex - 1) * pageSize);

                var query = await _connection.QueryMultipleAsync(sql, queryParameters, commandType: CommandType.Text);

                var groups = (await query.ReadAsync<GroupsResponse>()).ToList();
                var totalRow = await query.ReadSingleOrDefaultAsync<long>();

                return new ListGroupResponse
                {
                    Groups = groups,
                    TotalRow = (int)totalRow
                };
            }
            catch (Exception ex)
            {
                var error = $"GroupRepository - {Helpers.BuildErrorMessage(ex)}";
                throw new Exception(error);
            }
        }
    }
}
