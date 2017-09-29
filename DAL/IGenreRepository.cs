using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IGenreRepository
    {
        //C
        Genre Add(Genre Genre);
        //R
        List<Genre> GetAll();
        Genre Get(int Id);
        int GetCount();
        //U

        //D
        Genre Delete(int Id);
    }
}
