﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IVideoRepository
    {
        //C
        Video Add(Video video);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        int GetCount();
        //U
        
        //D
        Video Delete(int Id);
    }
}
