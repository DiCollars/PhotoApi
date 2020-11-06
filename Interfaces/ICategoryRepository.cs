using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category Get(int id);

        void Create(Category category);

        void Update(Category category);

        void Delete(int id);
    }
}
