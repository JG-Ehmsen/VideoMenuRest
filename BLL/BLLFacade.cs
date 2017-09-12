
using DAL;
using BLL.Services;
using BLL.BO;
using System;

namespace BLL
{
    public class BLLFacade
    {

        private static BLLFacade instance;
        private static DALFacade dalFacade;

        private BLLFacade()
        {
            GenerateVideos(20);
            dalFacade = new DALFacade();
        }

        public static BLLFacade GetInstance()
        {
            if (instance != null)
                return instance;
            else
                return instance = new BLLFacade();
        }

        public IVideoService VideoService
        {
            get { return new VideoService(dalFacade); }
        }

        public IRentalService RentalService
        {
            get { return new RentalService(dalFacade); }
        }

        private void GenerateVideos(int count)
        {
            String[] Authors = { "Billy Bob", "MacMoe", "SuperCoolDUde99", "Danny the Dude", "Me", "RealPerson", "KimK", "Someone Else" };

            String[] Genres = { "Random", "Funny", "Sad", "Gaming", "Music", "Hobbies", "DYI" };

            Random rnd = new Random();


            for (int i = 1; i < count; i++)
            {
                VideoBO vid = new VideoBO()
                {
                    Title = "Video " + i
                };
                int r = rnd.Next(Authors.Length);
                vid.Author = Authors[r];

                r = rnd.Next(Genres.Length);
                vid.Genre = Genres[r];

                VideoService.Add(vid);
            }
        }
    }
}
