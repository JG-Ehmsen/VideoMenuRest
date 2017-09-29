using BLL.BO;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class GenreService : IGenreService
    {
        private GenreConverter conv;
        private DALFacade _facade;

        public GenreService(DALFacade facade)
        {
            conv = new GenreConverter();
            _facade = facade;
        }

        public GenreBO Add(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Add(conv.Convert(genre));
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }

        public GenreBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(Id);
                if (genreEntity != null)
                {
                    uow.GenreRepository.Delete(Id);
                    uow.Complete();
                    return conv.Convert(genreEntity);
                }
                else
                    return null;
            }
        }

        public List<GenreBO> Filter(string filter)
        {
            List<GenreBO> filteredGenres = new List<GenreBO>();

            foreach (var i in GetAll())
            {
                if (i.ToString().ToLower().Contains(filter))
                {
                    filteredGenres.Add(i);
                }
            }

            return filteredGenres;
        }

        public GenreBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(Id);
                if (genreEntity == null) return null;
                return conv.Convert(genreEntity);
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public int GetCount()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.GetCount();
            }
        }

        public GenreBO Update(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var GenreEntity = uow.GenreRepository.Get(genre.Id);
                if (GenreEntity != null)
                {
                    uow.GenreRepository.Get(GenreEntity.Id)._Genre = genre.Genre;
                    uow.Complete();
                    return conv.Convert(GenreEntity);
                }
                else
                {
                    throw new InvalidOperationException("Genre not found.");
                }
            }
        }
    }
}
