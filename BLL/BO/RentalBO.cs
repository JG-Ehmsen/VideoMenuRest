using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.BO
{
    public class RentalBO
    {
        public int Id { get; set; }
        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public int VideoId { get; set; }
        public VideoBO Video { get; set; }

        public override string ToString()
        {
            return "#" + Id;
        }
    }
}
