
using DAL;
using BLL.Services;

namespace BLL
{
    public class BLLFacade
    {

        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }


    }
}
