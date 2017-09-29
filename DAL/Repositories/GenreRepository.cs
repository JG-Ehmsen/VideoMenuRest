using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Context;
using System.Linq;

namespace DAL.Repositories
{
    class GenreRepository : IGenreRepository
    {
        VideoAppContext _context;

        public GenreRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Genre Add(Genre genre)
        {
            var gen = Get(genre.Id);
            if (gen == null)
            {
                _context.Genres.Add(genre);
                return gen;
            }
            else
            {
                return null;
            }
        }

        public Genre Delete(int Id)
        {
            var genre = Get(Id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                return genre;
            }
            else
            {
                return null;
            }
        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(o => o.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public int GetCount()
        {
            return _context.Genres.Count();
        }
    }
}
