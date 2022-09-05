using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Library.Models.Dto;
using Library.Models.Library;
using Library.Repositories;

namespace Library.Services
{
    public class ReaderService : IReaderService
    {
        public const string BirthdayMessageError = "Некорректная дата рождения";
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IRegisterRepository _registryRepository;
        private readonly IMapper _mapper;

        public ReaderService(
            IReaderRepository readerRepository,
            IBookRepository bookRepository,
            IRegisterRepository registerRepository,
            IMapper mapper)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _registryRepository = registerRepository;
            _mapper = mapper;
        }

        public async Task<ReaderDto> GetById(Guid readerId)
        {
            return _mapper.Map<ReaderDto>(await _readerRepository.GetAsync(readerId));
        }

        public async Task<Guid> SaveReader(ReaderDto readerDto)
        {
            if (readerDto.Birthday < DateTime.Now.AddYears(-100) || readerDto.Birthday > DateTime.Now.AddYears(-6))
            {
                throw new ValidationException(BirthdayMessageError);
            }

            var readerToSave = readerDto.Id == null
                ? new Reader()
                : await _readerRepository.GetAsync(readerDto.Id.Value);
            _mapper.Map(readerDto, readerToSave);

            var readerId = readerDto.Id == null
                ? await _readerRepository.CreateAsync(readerToSave)
                : await _readerRepository.UpdateAsync(readerToSave);
            await _readerRepository.SaveAsync();
            return readerId;
        }

        public async Task<Guid> DeleteReader(Guid readerId)
        {
            var readerToDelete = await _readerRepository.GetAsync(readerId);
            readerToDelete.DeleteDateTime = DateTime.Now;

            await _readerRepository.UpdateAsync(readerToDelete);
            await _readerRepository.SaveAsync();

            return readerId;
        }

        public async Task<ReaderDto[]> FindReaders(string readerName)
        {
            var readers = await _readerRepository.FindReaders(readerName);
            return _mapper.Map<ReaderDto[]>(readers);
        }

        public async Task<ReaderReg[]> FindReadersWithBooks(string readerName)
        {
            var res = await _readerRepository.FindReadersWithBooks(readerName);
            return res;
        }

        public async Task<ReaderDto[]> GetAllReaders()
        {
            var readers = await _readerRepository.GetAllAsync();
            return _mapper.Map<ReaderDto[]>(readers);
        }

        public async Task<Guid> TakeBook(Guid readerId, Guid bookId)
        {
            var register = new Register
            {
                BookId = bookId,
                ReaderId = readerId,
                TakeDateTime = DateTime.Now,
            };
            var regId = await _registryRepository.CreateAsync(register);
            await _registryRepository.SaveAsync();
            return regId;
        }

        public async Task<Guid> GiveBook(Guid registerId)
        {
            var register = await _registryRepository.GetAsync(registerId);
            register.GiveDateTime = DateTime.Now;

            var regId = await _registryRepository.UpdateAsync(register);
            await _registryRepository.SaveAsync();
            return regId;
        }
    }
}
