using AutoMapper;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using ProcessManager.Interface;

namespace StoreBookWebApi.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookProcessManager _bookProcessManager;
        public readonly IMapper _mapper; //TODO mapper not need for now

        public BookController(IBookProcessManager bookProcessManager, IMapper mapper)
        {
            _mapper = mapper;
            _bookProcessManager = bookProcessManager;
        }

        [HttpGet("getBooks")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bookProcessManager.GetAll();
        }


        [HttpGet("getBookById")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookProcessManager.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost("saveBook")]
        public async Task<ActionResult<Book>> SaveBook(Book book)
        {
            var result = await _bookProcessManager.Save(book);

            return Ok(result);
        }

        [HttpDelete("deleteBookById")]
        public async Task<ActionResult> DeleteBookById(int id)
        {
            var book = await _bookProcessManager.GetById(id);
            await _bookProcessManager.Delete(book);
            return Ok();
        }
    }
}
