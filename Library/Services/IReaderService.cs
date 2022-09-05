using System;
using System.Threading.Tasks;
using Library.Models.Dto;
using Library.Models.Library;

namespace Library.Services
{
    public interface IReaderService
    {
        Task<ReaderDto> GetById(Guid readerId);

        Task<Guid> SaveReader(ReaderDto readerDto);

        Task<Guid> DeleteReader(Guid readerId);

        Task<ReaderDto[]> FindReaders(string readerName);

        Task<ReaderReg[]> FindReadersWithBooks(string readerName);

        Task<ReaderDto[]> GetAllReaders();

        Task<Guid> TakeBook(Guid readerId, Guid bookId);

        Task<Guid> GiveBook(Guid registerId);
    }
}
