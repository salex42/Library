using System.Threading.Tasks;
using Library.Models.Dto;
using Library.Models.Library;

namespace Library.Repositories
{
    public interface IReaderRepository : IBaseRepository<Reader>
    {
        Task<Reader[]> FindReaders(string searchTerm);

        Task<ReaderReg[]> FindReadersWithBooks(string searchTerm);
    }
}
