using BusinessObjects;
using DataManagers.Interface;
using ProcessManager.Interface;

namespace ProcessManager
{
    public class BookProcessManager : IBookProcessManager
    {
        private readonly IBookDataManager _repository;
        public BookProcessManager(IBookDataManager repository)
        {
            _repository = repository;
        }
        public async Task Delete(Book book)
        {
            await _repository.Delete(book);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Book> Save(Book book)
        {
            return await _repository.Save(book);
        }
    }
}
