namespace BOOKSTORE.DOMAIN.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
