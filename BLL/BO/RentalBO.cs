using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BO
{
    public class RentalBO
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public override string ToString()
        {
            return "#" + Id;
        }
    }
}
