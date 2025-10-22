using DataAccessLayer.Models;

namespace DataAccessLayer
{
    internal class BookRepository : IRepository<Book>
    {

        private static readonly List<Book> _books =
        [
                new() { Id = 1, Title = "Title1", PublishedYear = 2000, AuthorId = 4},
                new() { Id = 2, Title = "Title2", PublishedYear = 2002, AuthorId = 3},
                new() { Id = 3, Title = "Title3", PublishedYear = 1898, AuthorId = 1},
                new() { Id = 4, Title = "Title4", PublishedYear = 4812, AuthorId = 2},
        ];
        public async Task CreateAsync(Book obj)
        {
            await Task.Run(() =>
            {
                obj.Id = _books.OrderBy(book => book.Id).Last().Id + 1;
                _books.Add(obj);
            });
        }

        public async Task DeleteAsync(Book obj)
        {
            await Task.Run(() => _books.Remove(obj));
        }

        public async Task<IEnumerable<Book>?> GetAllAsync()
        {
            return await Task.Run(_books.ToArray);
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _books.FirstOrDefault(b => b.Id == id));
        }

        public async Task UpdateAsync(Book obj)
        {
            //Так как ссылочные типа и все такое то тут смысла нет даже
            await Task.Delay(10);
        }
    }
}
