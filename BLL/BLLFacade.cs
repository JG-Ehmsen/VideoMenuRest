
using DAL;
using BLL.Services;
using BLL.BO;
using System;

namespace BLL
{
    public class BLLFacade
    {
       

        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }

        public IRentalService RentalService
        {
            get { return new RentalService(new DALFacade()); }
        }

      
    }
}
