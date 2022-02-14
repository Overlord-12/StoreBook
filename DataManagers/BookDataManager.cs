using BusinessObjects;
using DataManagers.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataManagers
{
    public class BookDataManager : IBookDataManager
    {
        private readonly StoreDBContext _storeDBContext;

        public BookDataManager(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _storeDBContext.Books.ToListAsync();
        }
        public async Task Delete(Book book)
        {
            _storeDBContext.Remove(book);
            await _storeDBContext.SaveChangesAsync();
        }
        public async Task<Book> GetById(int id)
        {
            return await _storeDBContext.Books.FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<Book> Save(Book book)
        {
            try
            {
                _storeDBContext.Add(book);
                await _storeDBContext.SaveChangesAsync();
                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
