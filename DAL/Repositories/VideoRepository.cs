using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using System.Linq;
using DAL.Entities;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
            var vid = Get(video.ID);
            if (vid == null)
            {
                _context.Add(video);
                return video;
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
                return null;
            }
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
            return _context.Videos.Include(v => v.Genres).FirstOrDefault(x => x.ID == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos.Include(v => v.Genres).ToList();
        }

        public int GetCount()
        {
            return _context.Videos.Count();
        }
    }
}
