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
            if (rental != null)
            {
                return new Rental()
                {
                    Id = rental.Id,
                    RentalDate = rental.RentalDate,
                    DeliveryDate = rental.DeliveryDate
                };
            }
            else
                return null;
        }

        internal RentalBO Convert(Rental rental)
        {
            if (rental != null)
            {
                return new RentalBO()
                {
                    Id = rental.Id,
                    RentalDate = rental.RentalDate,
                    DeliveryDate = rental.DeliveryDate
                };
            }
            else
                return null;
        }
    }
}
