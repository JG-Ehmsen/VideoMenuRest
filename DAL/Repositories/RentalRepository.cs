using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Context;
using System.Linq;

namespace DAL.Repositories
{
    class RentalRepository : IRentalRepository
    {

        VideoAppContext _context;
        public RentalRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Rental Add(Rental rental)
        {
            _context.Rentals.Add(rental);
            return rental;
        }

        public Rental Delete(int Id)
        {
            var rental = Get(Id);
            _context.Rentals.Remove(rental);
            return rental;
        }

        public Rental Get(int Id)
        {
            return _context.Rentals.FirstOrDefault(o => o.Id == Id);
        }

        public List<Rental> GetAll()
        {
            var list = _context.Rentals.ToList();
            return list;
        }

        public int GetCount()
        {
            return _context.Rentals.Count();
        }
    }
}
