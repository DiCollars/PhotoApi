using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PhotoApi.Interfaces;
using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Services
{
    public class PhotoRepository : IPhotoRepository
    {
        private ApplicationDbContext _context;

        IWebHostEnvironment _appEnvironment;
        public PhotoRepository(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {

            _appEnvironment = appEnvironment;
            _context = context;
            //_photos = new List<Photo>
            //{
            //    new Photo()
            //    {
            //        Id = 1,
            //        Name = "Прогулка на природе",
            //        AuthorId = 1,
            //        AlbumId = 1,
            //        DateOfMade = new DateTime(2015,2,14),
            //        CameraModel = "Samsung galaxy-22of"
            //    },
            //    new Photo()
            //    {
            //        Id = 2,
            //        Name = "Поход в лунопарк",
            //        AuthorId = 1,
            //        AlbumId = 1,
            //        DateOfMade = new DateTime(2017,8,29)
            //        ,
            //        CameraModel = "Iphone 4s"
            //    },
            //    new Photo()
            //    {
            //        Id = 3,
            //        Name = "Модель Анастасия",
            //        AuthorId = 2,
            //        AlbumId = 2,
            //        DateOfMade = new DateTime(2010,1,9),
            //        CameraModel = "Canon 2200"
            //    },
            //    new Photo()
            //    {
            //        Id = 4,
            //        Name = "Новый год",
            //        AuthorId = 3,
            //        AlbumId = 3,
            //        DateOfMade = new DateTime(2018,4,22),
            //        CameraModel = "Xiaomi 6a"
            //    },
            //    new Photo()
            //    {
            //        Id = 5,
            //        Name = "Модель Владимир",
            //        AuthorId = 2,
            //        AlbumId = 2,
            //        DateOfMade = new DateTime(1997,11,29),
            //        CameraModel = "Nikon a-221"
            //    },
            //    new Photo()
            //    {
            //        Id = 6,
            //        Name = "Новая машина",
            //        AuthorId = 1,
            //        AlbumId = 1,
            //        DateOfMade = new DateTime(2020,3,6),
            //        CameraModel = "Honor 10 lite"
            //    },
            //    new Photo()
            //    {
            //        Id = 7,
            //        Name = "9 мая",
            //        AuthorId = 3,
            //        AlbumId = 3,
            //        DateOfMade = new DateTime(2000,5,9),
            //        CameraModel = "Canon I-33"
            //    }
            //};
        }

        public IEnumerable<Photo> GetAll()
        {
            return _context.Photos.ToList();
        }

        public Photo Get(int id)
        {
            return _context.Photos.Find(id);
        }

        public void Create(Photo photo, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                photo.Path = path;
                _context.Photos.Add(photo);
                _context.SaveChanges();
            }
        }

        public void Update(Photo photo)
        {
            _context.Photos.Update(photo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Photo photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                _context.SaveChanges();
            }
        }
    }
}
