namespace TRunner.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        void Complete();
        void Rollback();
    }
}
