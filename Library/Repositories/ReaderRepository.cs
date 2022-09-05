using System;
using System.Linq;
using System.Threading.Tasks;
using Library.DataBase;
using Library.Models.Dto;
using Library.Models.Library;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    internal class ReaderRepository : BaseRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Reader[]> FindReaders(string searchTerm)
        {
            return await _context.Readers
                .Where(x => EF.Functions.ILike(x.Fio, $"%{searchTerm}%"))
                .ToArrayAsync();
        }

        public async Task<ReaderReg[]> FindReadersWithBooks(string searchTerm)
        {
            return await _context.Readers
                .Include(x => x.Registers)
                .ThenInclude(x => x.Book)
                .Where(x => EF.Functions.ILike(x.Fio, $"%{searchTerm}%"))
                .Select(x => new ReaderReg
                {
                    Id = x.Id,
                    Fio = x.Fio,
                    BookNames = x.Registers.Select(y => y.Book.Name).ToArray()
                })
                .ToArrayAsync();
        }
    }
}
