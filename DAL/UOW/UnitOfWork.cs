using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }

        public IRentalRepository RentalRepository { get; internal set; }

        public IGenreRepository GenreRepository { get; internal set; }

        private VideoAppContext context;

        public UnitOfWork()
        {
            context = new VideoAppContext();
            context.Database.EnsureCreated();
            VideoRepository = new VideoRepository(context);
            RentalRepository = new RentalRepository(context);
            GenreRepository = new GenreRepository(context);

        }

        public int Complete()
        {

            try
            {
                var value = context.SaveChanges();
                return value;

            }
            catch (Exception e) {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
           
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
