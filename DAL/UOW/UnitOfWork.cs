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

        private VideoAppContext context;

        public UnitOfWork()
        {
            context = new VideoAppContext();
            VideoRepository = new VideoRepository(context);
            RentalRepository = new RentalRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
