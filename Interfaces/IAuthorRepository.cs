using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author Get(int id);

        Author FindByUserId(int userId);

        void Create(Author category);

        void Update(Author category);

        void Delete(int id);
    }
}
