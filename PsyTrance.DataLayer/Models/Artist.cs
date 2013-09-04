using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class Artist : IEquatable<Artist>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<AlbumArtist> AlbumArtists { get; set; }
        public virtual List<Album> Albums { get; set; }
        //public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Song> Songs { get; set; }

        public bool Equals(Artist artist)
        {
            return Title.Equals(artist.Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}