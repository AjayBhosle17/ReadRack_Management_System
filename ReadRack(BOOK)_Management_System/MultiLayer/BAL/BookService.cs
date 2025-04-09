using DAL.Entities;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }
        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }
        public async Task Create(Book book)
        {
            await _bookRepository.Create(book);
        }
        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }
    }
    
}
