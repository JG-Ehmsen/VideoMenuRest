using BLL.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IGenreService
    {
        //C
        GenreBO Add(GenreBO video);
        //R
        List<GenreBO> GetAll();
        GenreBO Get(int Id);
        List<GenreBO> Filter(String filter);
        int GetCount();
        //U
        GenreBO Update(GenreBO genre);
        //D
        GenreBO Delete(int Id);
    }
}
