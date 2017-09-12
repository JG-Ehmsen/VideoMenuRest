using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRentalRepository
    {
        //C
        Rental Add(Rental rental);
        //R
        List<Rental> GetAll();
        Rental Get(int Id);
        int GetCount();
        //U

        //D
        Rental Delete(int Id);
    }
}
