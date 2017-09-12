using BLL.BO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                ID = vid.ID,
                Title = vid.Title,
                Author = vid.Author,
                Genre = vid.Genre
            };
        }

        internal VideoBO Convert(Video vid)
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
