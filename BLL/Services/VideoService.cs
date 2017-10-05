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
        GenreConverter gConv;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
            this.conv = new VideoConverter();
            this.gConv = new GenreConverter();
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
                var vid = conv.Convert(uow.VideoRepository.Get(Id));

                //vid.Genres = vid.GenreIDs?.Select(id => gConv.Convert(uow.GenreRepository.Get(id))).ToList();

                vid.Genres = uow.GenreRepository.GetAllById(vid.GenreIDs).Select(g => gConv.Convert(g)).ToList();

                return vid;
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
                    var videoUpdated = conv.Convert(video);
                    //uow.VideoRepository.Get(video.ID).Author = video.Author;
                    //uow.VideoRepository.Get(video.ID).Title = video.Title;
                    vid.Author = videoUpdated.Author;
                    vid.Title = videoUpdated.Title;

                    //uow.VideoRepository.Get(video.ID).Genres = video.Genres;

                    vid.Genres.RemoveAll(vg => !videoUpdated.Genres.Exists(g => g.GenreID == vg.GenreID && g.VideoID == vg.VideoID));

                    videoUpdated.Genres.RemoveAll(vg => vid.Genres.Exists(g => g.GenreID == vg.GenreID && g.VideoID == vg.VideoID));

                    vid.Genres.AddRange(videoUpdated.Genres);

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
