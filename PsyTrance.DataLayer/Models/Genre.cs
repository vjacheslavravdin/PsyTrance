using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class Genre : IEquatable<Genre>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<AlbumArtist> AlbumArtists { get; set; }
        public virtual List<Album> Albums { get; set; }
        public virtual List<Artist> Artists { get; set; }
        //public virtual List<Genre> Genres { get; set; }
        public virtual List<Song> Songs { get; set; }

        public bool Equals(Genre genre)
        {
            return Title.Equals(genre.Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}