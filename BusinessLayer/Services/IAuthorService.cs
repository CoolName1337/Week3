using BusinessLayer.Dtos;

namespace BusinessLayer.Services
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorDto>> GetAllAsync();
        public Task<AuthorDto> GetByIdAsync(int id);
        public Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto);
        public Task<AuthorDto> UpdateAsync(int id, CreateAuthorDto createAuthorDto);
        public Task DeleteAsync(int id);
    }
}
