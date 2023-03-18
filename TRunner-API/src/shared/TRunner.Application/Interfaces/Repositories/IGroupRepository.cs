using TRunner.Domain.Models.Response;

namespace TRunner.Application.Interfaces.Repositories
{
    public interface IGroupRepository
    {
        Task<ListGroupResponse> GetGroups(int pageSize, int pageIndex);
    }
}
