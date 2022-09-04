using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Library.Models;
using Library.Models.Dto;
using Library.Services;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(nameof(GetBook))]
        public async Task<BookDto> GetBook([FromQuery] Guid bookId)
        {
            return await _bookService.GetById(bookId);
        }

        /// <summary>
        /// Изменение/добавление книги
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [HttpPost(nameof(SaveBook))]
        public async Task<Guid> SaveBook([FromBody] BookDto bookDto)
        {
            return await _bookService.SaveBook(bookDto);
        }

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPost(nameof(DeleteBook))]
        public async Task<Guid> DeleteBook([FromBody] Guid bookId)
        {
            return await _bookService.DeleteBook(bookId);
        }

        [HttpGet(nameof(FindBooks))]
        public async Task<BookDto[]> FindBooks([FromQuery] string bookName)
        {
            return await _bookService.FindBooks(bookName);
        }

        [HttpGet(nameof(GetAllBooks))]
        public async Task<BookDto[]> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }

        /// <summary>
        /// Выданные книги
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetIssuedBooks))]
        public async Task<BookDto[]> GetIssuedBooks()
        {
            return await _bookService.GetIssuedBooks();
        }

        /// <summary>
        /// Доступные книги
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAvailableBooks))]
        public async Task<BookDto[]> GetAvailableBooks()
        {
            return await _bookService.GetAvailableBooks();
        }
    }
}