using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    internal class AuthorRepository : IRepository<Author>
    {
        private static readonly List<Author> _authors =
        [
                new() { Id = 1, Name = "Chel1"},
                new() { Id = 2, Name = "Chel2"},
                new() { Id = 3, Name = "Chel3"},
                new() { Id = 4, Name = "Chel4"},
        ];
        public async Task<Author> CreateAsync(Author obj)
        {
            return await Task.Run(() =>
            {
                obj.Id = _authors.OrderBy(author => author.Id).Last().Id + 1;
                _authors.Add(obj);
                return obj;
            });
        }

        public async Task DeleteAsync(Author obj)
        {
            await Task.Run(() => _authors.Remove(obj));
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await Task.Run(_authors.ToArray);
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await Task.Run(() => _authors.FirstOrDefault(a => a.Id == id));
        }

        public async Task<Author?> UpdateAsync(Author obj)
        {
            return await Task.Run(() =>
            {
                var authorFromList = _authors.FirstOrDefault(a => a.Id == obj.Id);

                if (authorFromList is null)
                    return null;

                authorFromList.DateOfBirth = obj.DateOfBirth;
                authorFromList.Name = obj.Name;
                authorFromList.BooksIds = obj.BooksIds;

                return authorFromList; 
            });
        }
    }
}
