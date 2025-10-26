using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Exceptions;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    internal class BookService(IRepository<Book> bookRepository, IRepository<Author> authorRepository, IMapper mapper) : IBookService
    {
        public async Task<BookDto> CreateAsync(CreateBookDto createBookDto)
        {
            var authorEntity = await authorRepository.GetByIdAsync(createBookDto.AuthorId);
            if (authorEntity is null)
                throw new NotFoundException($"Author with id = {createBookDto.AuthorId} not found");

            var bookEntity = mapper.Map<Book>(createBookDto);
            return mapper.Map<BookDto>(await bookRepository.CreateAsync(bookEntity));
        }
        public async Task DeleteAsync(int id)
        {
            var bookEntity = await bookRepository.GetByIdAsync(id);
            if (bookEntity is null)
                throw new NotFoundException($"Book with id = {id} not found");

            await bookRepository.DeleteAsync(bookEntity);
        }
        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<BookDto>>(await bookRepository.GetAllAsync());
        }
        public async Task<BookDto> GetByIdAsync(int id)
        {
            var bookEntity = await bookRepository.GetByIdAsync(id);
            if (bookEntity is null)
                throw new NotFoundException($"Book with id = {id} not found");

            return mapper.Map<BookDto>(bookEntity);
        }
        public async Task<BookDto> UpdateAsync(int id, CreateBookDto createBookDto)
        {
            var bookEntity = await bookRepository.GetByIdAsync(id);
            if (bookEntity is null)
                throw new NotFoundException($"Book with id = {id} not found");
            var authorEntity = await authorRepository.GetByIdAsync(createBookDto.AuthorId);
            if (authorEntity is null)
                throw new NotFoundException($"Author with id = {createBookDto.AuthorId} not found");

            var mappedBookEntity = mapper.Map<Book>(createBookDto);
            mappedBookEntity.Id = id;
            var res = await bookRepository.UpdateAsync(mappedBookEntity);

            return mapper.Map<BookDto>(res);
        }
    }
}
