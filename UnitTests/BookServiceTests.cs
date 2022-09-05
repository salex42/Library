using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using AutoMapper;
using FluentAssertions;
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
                .With(x => x.Year, 2020)
                .With(x => x.Count, 5)
                .Create();
            var expectedBook = _mapper.Map<Book>(bookDto);
            var expectedBookId = Guid.NewGuid();

            var bookToCreate = new Book();
            _bookRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Book>()))
                .Callback((Book bookCr) => bookToCreate = bookCr)
                .ReturnsAsync(expectedBookId);
            _bookRepositoryMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);

            //Act
            var returnedId = await _bookService.SaveBook(bookDto);

            Assert.Equal(expectedBookId, returnedId);
            bookToCreate.Should().BeEquivalentTo(expectedBook);
        }

        [Fact]
        public async Task SuccessUpdateBook()
        {
            var expectedBookId = Guid.NewGuid();
            var oldBook = Fixture.Build<Book>()
                .Without(x => x.Registers)
                .Create();
            var bookDto = Fixture.Build<BookDto>()
                .With(x => x.Id, expectedBookId)
                .With(x => x.Year, 2020)
                .With(x => x.Count, 5)
                .Create();
            var expectedBook = _mapper.Map<Book>(bookDto);
            expectedBook.DeleteDateTime = oldBook.DeleteDateTime;

            var bookToUpdate = new Book();
            _bookRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Book>()))
                .Callback((Book bookCr) => bookToUpdate = bookCr)
                .ReturnsAsync(expectedBookId);
            _bookRepositoryMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);
            _bookRepositoryMock.Setup(x => x.GetAsync(expectedBookId))
                .ReturnsAsync(oldBook);

            //Act
            var returnedId = await _bookService.SaveBook(bookDto);

            Assert.Equal(expectedBookId, returnedId);
            bookToUpdate.Should().BeEquivalentTo(expectedBook);
        }

        [Fact]
        public async Task SaveBook_CountError()
        {
            var bookDto = Fixture.Build<BookDto>()
                .With(x => x.Count, -200)
                .Create();

            //Act
            var ex = await Assert.ThrowsAsync<ValidationException>(() => _bookService.SaveBook(bookDto));

            ex.Message.Should().BeEquivalentTo(BookService.CountMessageError);
        }

        [Theory]
        [InlineData(-200)]
        [InlineData(0)]
        [InlineData(800)]
        [InlineData(2050)]
        public async Task SaveBook_YearError(int year)
        {
            var bookDto = Fixture.Build<BookDto>()
                .With(x => x.Year, year)
                .With(x => x.Count, 5)
                .Create();

            //Act
            var ex = await Assert.ThrowsAsync<ValidationException>(() => _bookService.SaveBook(bookDto));

            ex.Message.Should().BeEquivalentTo(BookService.YearMessageError);
        }
    }
}
