using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLayer
{
    internal class AuthorService(IRepository<Author> repository) : IAuthorService
    {
        public async Task CreateAsync(string name, DateTime dateOfBirth)
        {
            var author = new Author { Name = name, DateOfBirth = dateOfBirth };
            await repository.CreateAsync(author);
        }
        public async Task DeleteAsync(int id)
        {
            var res = await GetByIdAsync(id);
            await repository.DeleteAsync(res);
        }
        public async Task<IEnumerable<Author>?> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(int id, string name, DateTime dateOfBirth)
        {
            var res = await GetByIdAsync(id);

            res.Name = name;
            res.DateOfBirth = dateOfBirth;

            await repository.UpdateAsync(res);
        }
    }
}
