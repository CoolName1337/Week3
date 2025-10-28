using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Exceptions;
using DataAccessEFLayer.Abstractions;
using DataAccessEFLayer.Entities;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    internal class AuthorService(
        IAuthorRepository authorRepository, 
        IBookRepository bookRepository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper, ILogger<AuthorService> _logger) : IAuthorService
    {
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto)
        {
            _logger.LogInformation("Try to create AUTHOR with params = {CreateAuthorDto}", createAuthorDto);

            await BooksVaildateAsync(createAuthorDto.BooksIds);

            var authorEntity = mapper.Map<Author>(createAuthorDto);
            await authorRepository.AddAsync(authorEntity);

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("AUTHOR with ID {id} has been created", authorEntity.Id);
            return mapper.Map<AuthorDto>(authorEntity);
        }
        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Try to delete AUTHOR with ID = {id}", id);

            var authorEntity = await AuthorValidateAsync(id);

            authorRepository.Remove(authorEntity);

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("AUTHOR with ID {id} has been deleted", id);
        }
        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            _logger.LogInformation("Try to get all AUTHORs");

            var res = await authorRepository.GetAllAsync();

            _logger.LogInformation("All AUTHORs were received");
            return mapper.Map<IEnumerable<AuthorDto>>(res);
        }
        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            _logger.LogInformation("Try to get AUTHOR with ID = {id}", id);

            var authorEntity = await AuthorValidateAsync(id);

            _logger.LogInformation("AUTHOR {name} with ID {id} was found", authorEntity.Name, authorEntity.Id);
            return mapper.Map<AuthorDto>(authorEntity);
        }
        public async Task<AuthorDto> UpdateAsync(UpdateAuthorDto updateAuthorDto)
        {
            _logger.LogInformation("Try to update AUTHOR with ID = {id}", updateAuthorDto.Id);

            var authorEntity = await AuthorValidateAsync(updateAuthorDto.Id);
            await BooksVaildateAsync(updateAuthorDto.BooksIds);

            authorEntity = mapper.Map<Author>(updateAuthorDto);
            authorEntity.Books = await GetBooksByIdsAsync(updateAuthorDto.BooksIds);

            authorRepository.Update(authorEntity);

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("AUTHOR with ID {id} was updated", updateAuthorDto.Id);
            return mapper.Map<AuthorDto>(authorEntity);
        }

        public async Task<IEnumerable<AuthorDto>> GetByFilterAsync(AuthorFilterDto authorFilterDto)
        {
            _logger.LogInformation("Try to get AUTHOR by FILTER : {authorFilterDto}", authorFilterDto);

            var repoFilter = mapper.Map<AuthorRepoFilter>(authorFilterDto);
            var res = await authorRepository.GetByFilterAsync(repoFilter);

            _logger.LogInformation("{count} AUTHORS by FILTER : {authorFilterDto} were founded", res.Count(), authorFilterDto);
            return mapper.Map<IEnumerable<AuthorDto>>(res);
        }


        private async Task<Author> AuthorValidateAsync(int id)
        {
            var authorEntity = await authorRepository.GetByIdAsync(id);
            if (authorEntity is null)
                throw new NotFoundException($"AUTHOR with ID = {id} NOT FOUND");

            return authorEntity;
        }

        private async Task BooksVaildateAsync(IEnumerable<int> booksIds)
        {
            var nonCorrectBooksIds = await GetNonCorrectBooksAsync(booksIds);
            if (nonCorrectBooksIds.Any())
                throw new NotFoundException($"BOOKs with NON-EXISTENT ID: {string.Join(',', nonCorrectBooksIds)}");
        }

        private async Task<IEnumerable<int>> GetNonCorrectBooksAsync(IEnumerable<int> booksIds)
        {
            List<int> nonCorrectBooksIds = new List<int>();

            foreach (var bookId in booksIds)
                if(await bookRepository.GetByIdAsync(bookId) is null)
                    nonCorrectBooksIds.Add(bookId);

            return nonCorrectBooksIds;
        }
        private async Task<ICollection<Book>> GetBooksByIdsAsync(IEnumerable<int> ids)
        {
            var books = new List<Book>();
            foreach (var bookId in ids)
                if(await bookRepository.GetByIdAsync(bookId) is Book book)
                    books.Add(book);

            return books;
        }

    }
}
