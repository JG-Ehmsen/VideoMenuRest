using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.BO
{
    public class VideoBO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Author { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return "#" + this.ID + " - " + this.Title + " by " + Author + " - " + this.Genre;
        }
    }
}
