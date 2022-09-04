using System.Linq;
using System.Threading.Tasks;
using Library.DataBase;
using Library.Models.Dto;
using Library.Models.Library;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    internal class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context) : base (context)
        {
        }

        public async Task<Book[]> GetIssuedBooks()
        {
            return await _context.Books.Where(x => x.Registers.Any(y => y.GiveDateTime == null)).ToArrayAsync();
        }
    }
}
