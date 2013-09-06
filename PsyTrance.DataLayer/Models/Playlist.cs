using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<Album> Albums { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}