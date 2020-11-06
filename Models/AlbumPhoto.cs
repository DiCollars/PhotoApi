using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Models
{
    public class AlbumPhoto
    {
        public Photo Photo { get; set; }
        public int PhotoId { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
