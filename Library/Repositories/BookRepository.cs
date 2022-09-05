using System;
using System.Linq;
using System.Threading.Tasks;
using Library.DataBase;
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

        public async Task<Book[]> GetAvailableBooks()
        {
            return await _context.Books.Where(x => (x.Registers.All(y => y.GiveDateTime == null) || x.Registers.Count == 0) && x.DeleteDateTime == null).ToArrayAsync();
        }

        public async Task<Book[]> FindBooks(string searchTerm)
        {
            return await _context.Books.Where(x => EF.Functions.ILike(x.Name, $"%{searchTerm}%")).ToArrayAsync();
        }
    }
}
