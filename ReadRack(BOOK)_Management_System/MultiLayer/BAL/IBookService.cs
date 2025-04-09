using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}
