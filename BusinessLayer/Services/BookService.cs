using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Exceptions;
using DataAccessEFLayer.Abstractions;
using DataAccessEFLayer.Entities;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    internal class BookService(
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper, ILogger<BookService> _logger) : IBookService
    {
        public async Task<BookDto> CreateAsync(CreateBookDto createBookDto)
        {
            _logger.LogInformation("Try to create BOOK with params = {CreateBookDto}", createBookDto);

            if (createBookDto.AuthorId is int id)
                await ValidateAuthorIdAsync(id);

            var bookEntity = mapper.Map<Book>(createBookDto);
            await bookRepository.AddAsync(bookEntity);

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("BOOK with ID {id} has been created", bookEntity.Id);
            return mapper.Map<BookDto>(bookEntity);
        }
        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Try to delete BOOK with ID = {id}", id);

            var bookEntity = await ValidateBookIdAsync(id);

            bookRepository.Remove(bookEntity);

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("BOOK with ID {id} has been deleted", id);
        }
        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            _logger.LogInformation("Try to get all BOOKs");

            var res = await bookRepository.GetAllAsync();

            _logger.LogInformation("All BOOKs were received");
            return mapper.Map<IEnumerable<BookDto>>(res);
        }
        public async Task<BookDto> GetByIdAsync(int id)
        {
            _logger.LogInformation("Try to get BOOK with ID = {id}", id);

            var bookEntity = await ValidateBookIdAsync(id);

            _logger.LogInformation("BOOK {title} with ID {id} was found", bookEntity.Title, bookEntity.Id);
            return mapper.Map<BookDto>(bookEntity);
        }
        public async Task<BookDto> UpdateAsync(UpdateBookDto updateBookDto)
        {
            _logger.LogInformation("Try to update BOOK with ID = {id}", updateBookDto.Id);

            await ValidateBookIdAsync(updateBookDto.Id);
            if(updateBookDto.AuthorId is int id)
                await ValidateAuthorIdAsync(id);

            var bookEntity = mapper.Map<Book>(updateBookDto);

            bookRepository.Update(bookEntity);

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("BOOK with ID {id} was updated", updateBookDto.Id);
            return mapper.Map<BookDto>(bookEntity);
        }
        public async Task<IEnumerable<BookDto>> GetByFilterAsync(BookFilterDto bookFilterDto)
        {
            _logger.LogInformation("Try to get BOOK by FILTER : {bookFilterDto}", bookFilterDto);

            var repoFilter = mapper.Map<BookRepoFilter>(bookFilterDto);
            var res = await bookRepository.GetByFilterAsync(repoFilter);

            _logger.LogInformation("{count} BOOKS by FILTER : {bookFilterDto} were founded", res.Count(), bookFilterDto);
            return mapper.Map<IEnumerable<BookDto>>(res);
        }
        private async Task<Book> ValidateBookIdAsync(int id)
        {
            var bookEntity = await bookRepository.GetByIdAsync(id);
            if (bookEntity is null)
                throw new NotFoundException($"BOOK with ID = {id} NOT FOUND");
            return bookEntity;
        }
        private async Task<Author> ValidateAuthorIdAsync(int id)
        {
            var authorEntity = await authorRepository.GetByIdAsync(id);
            if (authorEntity is null)
                throw new NotFoundException($"AUTHOR with ID = {id} NOT FOUND");
            return authorEntity;
        }

    }
}
