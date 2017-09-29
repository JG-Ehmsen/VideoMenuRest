using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string _Genre { get; set; }

        List<VideoGenre> Videos { get; set; }
    }
}
