using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Library.Models.Dto;
using Library.Models.Library;
using Library.Services;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet(nameof(GetReader))]
        public async Task<ReaderDto> GetReader([FromQuery] Guid readerId)
        {
            return await _readerService.GetById(readerId);
        }

        /// <summary>
        /// Изменение/добавление читателя
        /// </summary>
        /// <param name="readerDto"></param>
        /// <returns></returns>
        [HttpPost(nameof(SaveReader))]
        public async Task<Guid> SaveReader([FromBody] ReaderDto readerDto)
        {
            return await _readerService.SaveReader(readerDto);
        }

        /// <summary>
        /// Удаление читателя
        /// </summary>
        /// <param name="readerId"></param>
        /// <returns></returns>
        [HttpPost(nameof(DeleteReader))]
        public async Task<Guid> DeleteReader([FromBody] Guid readerId)
        {
            return await _readerService.DeleteReader(readerId);
        }

        [HttpGet(nameof(FindReaders))]
        public async Task<ReaderDto[]> FindReaders([FromQuery] string readerName)
        {
            return await _readerService.FindReaders(readerName);
        }

        [HttpGet(nameof(FindReadersWithBooks))]
        public async Task<ReaderReg[]> FindReadersWithBooks([FromQuery] string readerName)
        {
            return await _readerService.FindReadersWithBooks(readerName);
        }

        [HttpGet(nameof(GetAllReaders))]
        public async Task<ReaderDto[]> GetAllReaders()
        {
            return await _readerService.GetAllReaders();
        }

        /// <summary>
        /// Выдача книги
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(TakeBook))]
        public async Task<Guid> TakeBook([FromQuery] Guid readerId, [FromQuery] Guid bookId)
        {
            return await _readerService.TakeBook(readerId, bookId);
        }

        /// <summary>
        /// Сдача книги
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GiveBook))]
        public async Task<Guid> GiveBook([FromQuery] Guid registerId)
        {
            return await _readerService.GiveBook(registerId);
        }
    }
}