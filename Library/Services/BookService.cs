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
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> GetById(Guid bookId)
        {
            return _mapper.Map<BookDto>(await _bookRepository.GetAsync(bookId));
        }

        public async Task<Guid> SaveBook(BookDto bookDto)
        {
            var bookToSave = bookDto.Id == null
                ? new Book()
                : await _bookRepository.GetAsync(bookDto.Id.Value);
            _mapper.Map(bookDto, bookToSave);

            var bookId = bookDto.Id == null
                ? await _bookRepository.CreateAsync(bookToSave)
                : await _bookRepository.UpdateAsync(bookToSave);
            await _bookRepository.SaveAsync();
            return bookId;
        }

        public async Task<Guid> DeleteBook(Guid bookId)
        {
            var bookToDelete = await _bookRepository.GetAsync(bookId);
            bookToDelete.DeleteDateTime = DateTime.Now;

            await _bookRepository.UpdateAsync(bookToDelete);
            await _bookRepository.SaveAsync();

            return bookId;
        }

        public async Task<BookDto[]> FindBooks(string bookName)
        {
            var books = await _bookRepository.FindBooks(bookName);
            return _mapper.Map<BookDto[]>(books);
        }

        public async Task<BookDto[]> GetAllBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<BookDto[]>(books);
        }

        public async Task<BookDto[]> GetIssuedBooks()
        {
            var issuedBooks = await _bookRepository.GetIssuedBooks();
            return _mapper.Map<BookDto[]>(issuedBooks);
        }

        public async Task<BookDto[]> GetAvailableBooks()
        {
            var books = await _bookRepository.GetAvailableBooks();
            return _mapper.Map<BookDto[]>(books);
        }
    }
}
