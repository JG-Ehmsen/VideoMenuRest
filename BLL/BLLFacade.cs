
using DAL;
using BLL.Services;

namespace BLL
{
    public class BLLFacade
    {

        private static BLLFacade facade;

        private BLLFacade()
        {

        }

        public static BLLFacade getInstance()
        {
            if (facade != null)
            {
                return facade;
            }
            else
                return facade = new BLLFacade();
        }

        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }


    }
}
