using DAL.Repositories;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DALFacade
    {

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
