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
            if (vid != null)
            {
                return new Video()
                {
                    ID = vid.ID,
                    Title = vid.Title,
                    Author = vid.Author,
                    Genre = vid.Genre
                };
            }
            else
                return null;
        }

        internal VideoBO Convert(Video vid)
        {
            if (vid != null)
            {
                return new VideoBO()
                {
                    ID = vid.ID,
                    Title = vid.Title,
                    Author = vid.Author,
                    Genre = vid.Genre
                };
            }
            else
                return null;
        }
    }
}
