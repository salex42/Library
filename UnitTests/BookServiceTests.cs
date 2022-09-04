using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Library;
using Library.Models.Dto;
using Library.Models.Library;
using Library.Repositories;
using Library.Services;
using Moq;
using Xunit;

namespace UnitTests
{
    public class BookServiceTests
    {
        public readonly Fixture Fixture;
        private readonly BookService _bookService;
        private readonly MockRepository _mockRepository;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly IMapper _mapper;


        public BookServiceTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper();

            Fixture = new Fixture();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _bookRepositoryMock = _mockRepository.Create<IBookRepository>(MockBehavior.Strict);
            _bookService = new BookService(_bookRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task SuccessAddBook()
        {
            var bookDto = Fixture.Build<BookDto>()
                .Without(x => x.Id)
                .Create();
            var book = _mapper.Map<Book>(bookDto);
            var expectedBookId = Guid.NewGuid();


            _bookRepositoryMock.Setup(x => x.CreateAsync(book))
                .ReturnsAsync(expectedBookId);
            var returnedId = await _bookService.SaveBook(bookDto);

            Assert.Equal(expectedBookId, returnedId);
        }
    }
}
