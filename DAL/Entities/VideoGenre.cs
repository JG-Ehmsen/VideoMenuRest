using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class VideoGenre
    {
        public int VideoID { get; set; }
        public Video Video { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
