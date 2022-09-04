using System;
using System.Threading.Tasks;
using AutoMapper;
using Library.Models.Dto;
using Library.Models.Library;
using Library.Repositories;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(
                IBaseRepository<Book> bookRepository,
                IMapper mapper
            )
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> GetById(Guid bookId)
        {
            return _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
        }

        public async Task<Guid> SaveBook(BookDto bookDto)
        {
            var bookId = Guid.NewGuid();
            var book = _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
            return bookId;
        }

        public async Task<Guid> DeleteBook(BookDto bookDto)
        {
            var bookId = Guid.NewGuid();
            var book = _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
            return bookId;
        }

        public async Task<BookDto[]> FindBooks(string bookName)
        {
            var bookId = Guid.NewGuid();
            var book = _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
            return new []{ book };
        }

        public async Task<BookDto[]> GetAllBooks()
        {
            var bookId = Guid.NewGuid();
            var book = _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
            return new []{ book };
        }

        public async Task<BookDto[]> GetIssuedBooks()
        {
            var bookId = Guid.NewGuid();
            var book = _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
            return new[] { book };
        }

        public async Task<BookDto[]> GetAvailableBooks()
        {
            var bookId = Guid.NewGuid();
            var book = _mapper.Map<BookDto>(await _bookRepository.Get(bookId));
            return new[] { book };
        }
    }
}
