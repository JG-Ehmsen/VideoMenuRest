using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using System.Linq;
using DAL.Entities;

namespace DAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext _context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public void Add(Video video)
        {
            _context.Videos.Add(video);
        }

        public void Delete(int Id)
        {
            Video vid = Get(Id);
            if (vid != null)
            {
                _context.Remove(vid);
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
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
