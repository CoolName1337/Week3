using BusinessLayer.Dtos;

namespace BusinessLayer.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllAsync();
        public Task<BookDto> GetByIdAsync(int id);
        public Task<BookDto> CreateAsync(CreateBookDto createBookDto);
        public Task<BookDto> UpdateAsync(UpdateBookDto updateBookDto);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<BookDto>> GetByFilterAsync(BookFilterDto bookFilterDto);
    }
}
