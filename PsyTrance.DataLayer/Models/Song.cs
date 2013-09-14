using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class Song : IEquatable<Song>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string File { get; set; }

        public int Disk { get; set; }
        public int Track { get; set; }

        public virtual List<AlbumArtist> AlbumArtists { get; set; }
        public virtual List<Album> Albums { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }

        public bool Equals(Song song)
        {
            return Title.Equals(song.Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}