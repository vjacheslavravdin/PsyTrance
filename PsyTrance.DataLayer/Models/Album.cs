using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class Album : IEquatable<Album>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Folder { get; set; }

        public virtual List<AlbumArtist> AlbumArtists { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Song> Songs { get; set; }

        public bool Equals(Album album)
        {
            return Title.Equals(album.Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}