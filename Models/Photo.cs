using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string Path { get; set; }
        public DateTime DateOfMade { get; set; }
        public string CameraModel { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public List<AlbumPhoto> AlbumPhotos { get; set; }
        public Photo()
        {
            AlbumPhotos = new List<AlbumPhoto>();
        }
    }
}
