using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class Playlist
    {
        private List<Album> _albums;
        private List<Song> _songs;

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<Album> Albums
        {
            get { return _albums ?? (new List<Album>()); }
            set { _albums = value; }
        }

        public virtual List<Song> Songs
        {
            get { return _songs ?? (new List<Song>()); }
            set { _songs = value; }
        }
    }
}