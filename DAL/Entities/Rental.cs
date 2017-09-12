using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
