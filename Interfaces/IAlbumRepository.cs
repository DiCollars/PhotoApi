using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();

        Album Get(int id);

        void Create(Album category);

        void Update(Album category);

        void Delete(int id);
    }
}
