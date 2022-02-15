using BusinessObjects;

namespace ProcessManager.Interface
{
    public interface IBookProcessManager
    {
        Task<Book> Save(Book book);
        Task Delete(Book book);
        Task<Book> GetById(int id);
        Task<List<Book>> GetAll();
    }
}
