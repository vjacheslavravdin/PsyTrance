using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsyTrance.PresentationLayer.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Artist> Artists { get; set; }
        public List<Genre> Genres { get; set; }
        //public List<Song> Songs { get; set; }
    }
}