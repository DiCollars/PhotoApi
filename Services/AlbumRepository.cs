using PhotoApi.Interfaces;
using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Services
{
    public class AlbumRepository : IAlbumRepository
    {
        private ApplicationDbContext _context;

        public AlbumRepository(ApplicationDbContext context)
        {
            _context = context;
            //_categories = new List<Album>
            //{
            //   new Album()
            //   {
            //        Id = 1,
            //        Name = "Мои личные снимки",
            //        AuthorId = 1,
            //        PhotoIds = new List<int>{1, 2, 6}
            //   },
            //   new Album()
            //   {
            //        Id = 2,
            //        Name = "Портфолио",
            //        AuthorId = 2,
            //        PhotoIds = new List<int>{3, 5}
            //   },
            //    new Album()
            //   {
            //        Id = 3,
            //        Name = "Праздники",
            //        AuthorId = 3,
            //        PhotoIds = new List<int>{4, 7}
            //   }
            //};
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        public Album Get(int id)
        {
            return _context.Albums.Find(id);
        }

        public void Create(Album author)
        {
            _context.Albums.Add(author);
            _context.SaveChanges();
        }

        public void Update(Album category)
        {
            _context.Albums.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Album album = _context.Albums.FirstOrDefault(p => p.Id == id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }
    }
}
