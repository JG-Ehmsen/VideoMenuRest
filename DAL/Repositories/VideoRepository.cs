using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using System.Linq;
using DAL.Entities;

namespace DAL.Repositories
{
    class VideoRepository : IVideoRepository
    {
        VideoAppContext _context;

        public VideoRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Video Add(Video video)
        {
            _context.Videos.Add(video);
            return video;
        }

        public Video Delete(int Id)
        {
            Video vid = Get(Id);
            if (vid != null)
            {
                _context.Remove(vid);
                return vid;
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
                return null;
            }
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.ID == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }

        public int GetCount()
        {
            return _context.Videos.Count();
        }
    }
}
