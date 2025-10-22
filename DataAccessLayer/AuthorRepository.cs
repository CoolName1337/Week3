using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
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
        public async Task CreateAsync(Author obj)
        {
            await Task.Run(() =>
            {
                obj.Id = _authors.OrderBy(author => author.Id).Last().Id + 1;
                _authors.Add(obj);
            });
        }

        public async Task DeleteAsync(Author obj)
        {
            await Task.Run(() => _authors.Remove(obj));
        }

        public async Task<IEnumerable<Author>?> GetAllAsync()
        {
            return await Task.Run(_authors.ToArray);
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _authors.FirstOrDefault(a => a.Id == id));
        }

        public async Task UpdateAsync(Author obj)
        {
            //Так как ссылочные типа и все такое то тут смысла нет даже
            await Task.Delay(10);
        }
    }
}
