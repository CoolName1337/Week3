using BusinessLayer.Dtos;

namespace BusinessLayer.Services
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorDto>> GetAllAsync();
        public Task<AuthorDto> GetByIdAsync(int id);
        public Task<AuthorDto> CreateAsync(CreateAuthorDto createAuthorDto);
        public Task<AuthorDto> UpdateAsync(UpdateAuthorDto updateAuthorDto);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<AuthorDto>> GetByFilterAsync(AuthorFilterDto authorFilterDto);
    }
}
