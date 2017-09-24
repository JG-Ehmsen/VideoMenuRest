using System;

namespace DAL.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Video Video { get; set; }
    }
}
