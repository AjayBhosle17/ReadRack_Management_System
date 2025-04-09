using BAL;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BOOK_API.Controllers
{
    [RoutePrefix("api/book")]
    public class BookController : ApiController
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

     

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            IEnumerable<Book> books = await _service.GetAll();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Book book = await _service.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null");
            }

            await _service.Create(book);
            return Created($"api/book/{book.Id}", book);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Book book)
        {
            if (book == null || id != book.Id)
            {
                return BadRequest("Invalid book data.");
            }

            var existingBook = await _service.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            await _service.Update(book);
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var existingBook = await _service.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return Ok($"Book with ID {id} deleted");
        }
    }
}
