using System.Collections.Generic;

namespace DAL.Entities
{
    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public List<VideoGenre> Genres { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
