using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Context;
using System.Linq;
using System.Diagnostics;

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
            var rent = Get(rental.Id);
            if (rental == null)
            {
                _context.Add(rental);
                return rental;
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
                return null;
            }
        }

        public Rental Delete(int Id)
        {
            var rental = Get(Id);
            if (rental != null)
            {
                _context.Remove(rental);
                return rental;
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
                return null;
            }
        }

        public Rental Get(int Id)
        {
            Debug.WriteLine("Removed video with ID: " + Id);
            return _context.Rentals.FirstOrDefault(o => o.Id == Id);
        }

        public List<Rental> GetAll()
        {
            var list = _context.Rentals.ToList();
            Debug.WriteLine("Returning a list!");
            return list;
        }

        public int GetCount()
        {
            return _context.Rentals.Count();
        }
    }
}
