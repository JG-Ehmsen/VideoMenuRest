using System.ComponentModel.DataAnnotations;

namespace BLL.BO
{
    public class VideoBO
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return "#" + this.ID + " - " + this.Title + " by " + Author + " - " + this.Genre;
        }
    }
}
