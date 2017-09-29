using BLL.BO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class GenreConverter
    {
        internal Genre Convert(GenreBO genre)
        {
            if (genre != null)
            {
                return new Genre()
                {
                    Id = genre.Id,
                    _Genre = genre.Genre
                };
            }
            else
                return null;

        }

        internal GenreBO Convert(Genre genre)
        {
            if (genre != null)
            {
                return new GenreBO()
                {
                    Id = genre.Id,
                    Genre = genre._Genre
                };
            }
            else
                return null;
        }
    }
}
