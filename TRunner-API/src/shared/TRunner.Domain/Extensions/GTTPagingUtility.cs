namespace TRunner.Domain.Extensions
{
    public class TRunnerPagingUtility
    {
        public static TRunnerPageResults<T> CreatePagedResultsQuery<T>(
            IEnumerable<T> results,
            int page,
            int pageSize,
            int totalNumberOfRecords)
        {
            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return new TRunnerPageResults<T>
            {
                Results = results,
                PageNumber = page,
                PageSize = pageSize,
                TotalNumberOfPages = totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords
            };
        }
    }
}
