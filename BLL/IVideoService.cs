using BLL.BO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public interface IVideoService
    {
        //C
        void Add(VideoBO video);
        void AddVideos(List<VideoBO> videos);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        List<VideoBO> Filter(String filter);
        int GetCount();
        //U
        VideoBO Update(VideoBO video);
        //D
        void Delete(int Id);
    }
}
