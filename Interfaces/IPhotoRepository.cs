using Microsoft.AspNetCore.Http;
using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Interfaces
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAll();

        Photo Get(int Id);

        void Create(Photo photo, IFormFile uploadedFile);

        void Update(Photo photo);

        void Delete(int id);
    }
}
