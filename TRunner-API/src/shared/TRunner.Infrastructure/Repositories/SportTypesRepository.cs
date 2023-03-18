using Microsoft.EntityFrameworkCore;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;
using TRunner.Infrastructure.ConnectionStrings;

namespace TRunner.Infrastructure.Repositories
{
    public class SportTypesRepository : ISportTypesRepository
    {
        #region Private Members
        private readonly TRunnerDbContext _trunnerDbContext;
        #endregion

        #region Constructors
        public SportTypesRepository(TRunnerDbContext trunnerDbContext)
        {
            _trunnerDbContext = trunnerDbContext;
        }
        #endregion

        public IQueryable<SportType> GetAllSportTypes()
        {
            var result = _trunnerDbContext.SportTypes.AsNoTracking();

            return result;
        }
    }
}