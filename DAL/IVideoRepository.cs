using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IVideoRepository
    {
        //C
        void Add(Video video);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        int GetCount();
        //U
        
        //D
        void Delete(int Id);
    }
}
