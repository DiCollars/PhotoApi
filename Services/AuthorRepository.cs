using PhotoApi.Interfaces;
using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author Get(int id)
        {
            return _context.Authors.Find(id);
        }

        public Author FindByUserId(int userId)
        {
            return _context.Authors.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author category)
        {
            _context.Authors.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Author author = _context.Authors.FirstOrDefault(p => p.Id == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
