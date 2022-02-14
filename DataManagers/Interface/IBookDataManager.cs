using BusinessObjects;

namespace DataManagers.Interface
{
    public interface IBookDataManager
    {
        Task<Book> Save(Book user);
        Task Delete(Book user);
        Task<Book> GetById(int id);
        Task<List<Book>> GetAll();
    }
}
