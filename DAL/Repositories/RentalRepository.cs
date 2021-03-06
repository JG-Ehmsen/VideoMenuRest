﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Context;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
            if (rent == null)
            {
                _context.Rentals.Add(rental);
                return rental;
            }
            else
            {
                return null;
            }
        }

        public Rental Delete(int Id)
        {
            var rental = Get(Id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                return rental;
            }
            else
            {
                return null;
            }
        }

        public Rental Get(int Id)
        {
            return _context.Rentals.FirstOrDefault(o => o.Id == Id);
        }

        public List<Rental> GetAll()
        {
            return _context.Rentals.ToList();
        }

        public int GetCount()
        {
            return _context.Rentals.Count();
        }
    }
}
