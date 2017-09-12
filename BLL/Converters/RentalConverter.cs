using BLL.BO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class RentalConverter
    {
        internal Rental Convert(RentalBO rental)
        {
            return new Rental()
            {
                Id = rental.Id,
                RentalDate = rental.RentalDate,
                DeliveryDate = rental.DeliveryDate
            };
        }

        internal RentalBO Convert(Rental rental)
        {
            return new RentalBO()
            {
                Id = rental.Id,
                RentalDate = rental.RentalDate,
                DeliveryDate = rental.DeliveryDate
            };
        }
    }
}
