using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models.Dto;

namespace Library.Services
{
    public interface IBookService
    {
        Task<BookDto> GetById(Guid bookId);

        Task<Guid> SaveBook(BookDto bookDto);

        Task<Guid> DeleteBook(BookDto bookDto);

        Task<BookDto[]> FindBooks(string bookName);

        Task<BookDto[]> GetAllBooks();

        Task<BookDto[]> GetIssuedBooks();

        Task<BookDto[]> GetAvailableBooks();
    }
}
