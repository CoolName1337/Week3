using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Exceptions;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    internal class AuthorService(IRepository<Author> authorRepository, IRepository<Book> bookRepository, IMapper mapper) : IAuthorService
    {
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto)
        {
            await BooksVaildateAsync(createAuthorDto);

            var authorEntity = mapper.Map<Author>(createAuthorDto);
            return mapper.Map<AuthorDto>(await authorRepository.CreateAsync(authorEntity));
        }
        public async Task DeleteAsync(int id)
        {
            var authorEntity = await AuthorValidateAsync(id);

            await authorRepository.DeleteAsync(authorEntity);
        }
        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<AuthorDto>>(await authorRepository.GetAllAsync());
        }
        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var authorEntity = await AuthorValidateAsync(id);

            return mapper.Map<AuthorDto>(authorEntity);
        }
        public async Task<AuthorDto> UpdateAsync(int id, CreateAuthorDto createAuthorDto)
        {
            await AuthorValidateAsync(id);
            await BooksVaildateAsync(createAuthorDto);

            var mappedAuthorEntity = mapper.Map<Author>(createAuthorDto);
            mappedAuthorEntity.Id = id;
            var res = await authorRepository.UpdateAsync(mappedAuthorEntity);

            return mapper.Map<AuthorDto>(res);
        }

        private async Task<Author> AuthorValidateAsync(int id)
        {
            var authorEntity = await authorRepository.GetByIdAsync(id);
            if (authorEntity is null)
                throw new NotFoundException($"Author with id = {id} not found");
            return authorEntity;
        }

        private async Task BooksVaildateAsync(CreateAuthorDto createAuthorDto)
        {
            var nonCorrectBooksIds = await GetNonCorrectBooksAsync(createAuthorDto);
            if (nonCorrectBooksIds.Any())
                throw new NotFoundException($"Books with non-existent ids: {string.Join(',', nonCorrectBooksIds)}");
        }

        private async Task<IEnumerable<int>> GetNonCorrectBooksAsync(CreateAuthorDto createAuthorDto)
        {
            List<int> nonCorrectBooksIds = new List<int>();

            foreach (var bookId in createAuthorDto.BooksIds)
                if(await bookRepository.GetByIdAsync(bookId) is null)
                    nonCorrectBooksIds.Add(bookId);

            return nonCorrectBooksIds;
        }

    }
}
