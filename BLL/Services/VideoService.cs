using System;
using System.Collections.Generic;
using DAL;
using BLL.BO;
using DAL.Entities;
using System.Linq;
using BLL.Converters;

namespace BLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        VideoConverter conv;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
            this.conv = new VideoConverter();
        }

        public VideoBO Add(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {

                var vid = uow.VideoRepository.Add(conv.Convert(video));
                uow.Complete();
                return conv.Convert(vid);
            }
        }

        public void AddVideos(List<VideoBO> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var item in videos)
                {
                    uow.VideoRepository.Add(conv.Convert(item));
                }
                uow.Complete();
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var vid = uow.VideoRepository.Get(Id);
                if (vid != null)
                {
                    uow.VideoRepository.Delete(Id);
                    uow.Complete();
                    return conv.Convert(vid);
                }
                else
                    return null;
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(conv.Convert).ToList();
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
                    //uow.VideoRepository.Get(video.ID).Genres = video.Genres;
                    uow.Complete();
                    return conv.Convert(vid);
                }
                else
                {
                    throw new InvalidOperationException("Video not found.");
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
    }
}
