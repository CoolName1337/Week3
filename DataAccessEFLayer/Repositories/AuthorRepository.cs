using DataAccessEFLayer.Entities;
using DataAccessEFLayer.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEFLayer.Repositories
{
    public class AuthorRepository(LibraryDbContext _db) : IAuthorRepository
    {
        public IQueryable<Author> Query()
        {
            return _db.Authors;
        }

        public async Task AddAsync(Author obj)
        {
            await _db.Authors.AddAsync(obj);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _db.Authors.AsNoTracking().Include(a => a.Books).ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _db.Authors.AsNoTracking().Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Remove(Author obj)
        {
            _db.Authors.Remove(obj);
        }

        public void Update(Author obj)
        {
            _db.Authors.Update(obj);
        }

        public async Task<IEnumerable<Author>> GetAuthorsByNameAsync(string name)
        {
            return await _db.Authors.AsNoTracking().Where(a => a.Name.Contains(name)).Include(a => a.Books).ToListAsync();
        }

        public async Task<Author?> GetAuthorByBookIdAsync(int id)
        {
            return await _db.Authors.AsNoTracking().Include(a => a.Books).FirstOrDefaultAsync(a => a.Books.Any(b => b.Id == id));
        }

        public async Task<IEnumerable<Author>> GetByFilterAsync(AuthorRepoFilter filter)
        {
            var q = _db.Authors.Include(a=>a.Books).AsQueryable();

            if (!string.IsNullOrEmpty(filter.AuthorName))
                q = q.Where(a => a.Name.Contains(filter.AuthorName));

            if (!string.IsNullOrEmpty(filter.BookTitle))
                q = q.Where(a => a.Books.Any(b => b.Title.Contains(filter.BookTitle)));

            if (filter.BirthAfter is DateOnly afterDate)
                q = q.Where(a => a.DateOfBirth > afterDate);

            if (filter.BookId is int bookId)
                q = q.Where(a => a.Books.Any(b=>b.Id == bookId));

            return await q.AsNoTracking().ToListAsync();
        }
    }
}
