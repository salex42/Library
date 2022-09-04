using System.Threading.Tasks;
using Library.Models.Dto;
using Library.Models.Library;

namespace Library.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book[]> GetIssuedBooks();
    }
}
