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

        Task<Guid> DeleteBook(Guid bookId);

        Task<BookDto[]> FindBooks(string bookName);

        Task<BookDto[]> GetAllBooks();

        Task<BookDto[]> GetIssuedBooks();

        Task<BookDto[]> GetAvailableBooks();
    }
}
