using BLL.BO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Genres = vid.Genres?.Select(g => new VideoGenre()
                    {
                        GenreID = g.Id,
                        VideoID = vid.ID
                    }).ToList(),
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
                    Genres = vid.Genres?.Select(g => new GenreBO()
                    {
                        Id = g.VideoID,
                        Genre = g.Genre?._Genre
                    }).ToList()
                };
            }
            else
                return null;
        }
    }
}
