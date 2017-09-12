using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        IRentalRepository RentalRepository { get; }

        int Complete();
    }
}
