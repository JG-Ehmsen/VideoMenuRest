using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BO
{
    public class GenreBO
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return Genre;
        }
    }
}
