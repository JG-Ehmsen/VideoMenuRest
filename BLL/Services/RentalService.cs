using System;
using System.Collections.Generic;
using System.Text;
using BLL.BO;
using DAL;
using BLL.Converters;
using System.Linq;

namespace BLL.Services
{
    public class RentalService : IRentalService
    {

        private RentalConverter conv;
        private DALFacade _facade;

        public RentalService(DALFacade facade)
        {
            conv = new RentalConverter();
            _facade = facade;
        }

        public RentalBO Add(RentalBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Add(conv.Convert(rental));
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(Id);
                if (rentalEntity != null)
                {
                    uow.RentalRepository.Delete(Id);
                    uow.Complete();
                    return conv.Convert(rentalEntity);
                }
                else
                    return null;
            }
        }

        public List<RentalBO> Filter(string filter)
        {
            List<RentalBO> filteredRentals = new List<RentalBO>();

            foreach (var i in GetAll())
            {
                if (i.ToString().ToLower().Contains(filter))
                {
                    filteredRentals.Add(i);
                }
            }

            return filteredRentals;
        }

        public RentalBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return conv.Convert(uow.RentalRepository.Get(Id));
            }
        }

        public List<RentalBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.RentalRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public int GetCount()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.RentalRepository.GetCount();
            }
        }

        public RentalBO Update(RentalBO rental)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var RentalEntity = uow.RentalRepository.Get(rental.Id);
                if (RentalEntity != null)
                {
                    uow.RentalRepository.Get(RentalEntity.Id).DeliveryDate = rental.DeliveryDate;
                    uow.RentalRepository.Get(RentalEntity.Id).RentalDate = rental.RentalDate;
                    uow.Complete();
                    return conv.Convert(RentalEntity);
                }
                else
                {
                    throw new InvalidOperationException("Rental not found.");
                }
            }
        }
    }
}
