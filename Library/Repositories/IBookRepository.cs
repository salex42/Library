using System.Threading.Tasks;
using Library.Models.Library;

namespace Library.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book[]> GetIssuedBooks();

        Task<Book[]> GetAvailableBooks();

        Task<Book[]> FindBooks(string searchTerm);
    }
}
