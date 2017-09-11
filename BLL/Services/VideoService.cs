using System;
using System.Collections.Generic;
using DAL;
using BLL.BO;
using DAL.Entities;
using System.Linq;

namespace BLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
            GenerateVideos(20);
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

                Add(vid);
            }
        }

        public void Add(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {

                uow.VideoRepository.Add(Convert(video));
                uow.Complete();
            }
        }

        public void AddVideos(List<VideoBO> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var item in videos)
                {
                    uow.VideoRepository.Add(Convert(item));
                }
                uow.Complete();
            }
        }

        public void Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                uow.VideoRepository.Delete(Id);
                uow.Complete();
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(Convert).ToList();
            }
        }

        public int GetCount()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetCount();
            }
        }

        public VideoBO Update(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                Video vid = uow.VideoRepository.Get(video.ID);
                if (vid != null)
                {
                    uow.VideoRepository.Get(video.ID).Author = video.Author;
                    uow.VideoRepository.Get(video.ID).Title = video.Title;
                    uow.VideoRepository.Get(video.ID).Genre = video.Genre;
                    uow.Complete();
                    return Convert(vid);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<VideoBO> Filter(String filter)
        {
            List<VideoBO> filteredVideos = new List<VideoBO>();

            foreach (var i in GetAll())
            {
                if (i.ToString().ToLower().Contains(filter))
                {
                    filteredVideos.Add(i);
                }
            }

            return filteredVideos;
        }

        private Video Convert(VideoBO vid)
        {
            return new Video()
            {
                ID = vid.ID,
                Title = vid.Title,
                Author = vid.Author,
                Genre = vid.Genre
            };
        }

        private VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                ID = vid.ID,
                Title = vid.Title,
                Author = vid.Author,
                Genre = vid.Genre
            };
        }
    }
}
