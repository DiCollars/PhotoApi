using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public List<AlbumPhoto> AlbumPhotos { get; set; }
        public Album()
        {
            AlbumPhotos = new List<AlbumPhoto>();
        }
    }
}
