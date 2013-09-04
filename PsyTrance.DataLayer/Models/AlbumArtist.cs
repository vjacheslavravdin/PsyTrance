using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class AlbumArtist : IEquatable<AlbumArtist>
    {
        //private List<AlbumArtist> _albumArtists;
        private List<Album> _albums;
        private List<Artist> _artists;
        private List<Genre> _genres;
        private List<Song> _songs;

        public int Id { get; set; }

        public string Title { get; set; }

        //public virtual List<AlbumArtist> AlbumArtists
        //{
        //    get { return _albumArtists ?? (new List<AlbumArtist>()); }
        //    set { _albumArtists = value; }
        //}

        public virtual List<Album> Albums
        {
            get { return _albums ?? (new List<Album>()); }
            set { _albums = value; }
        }

        public virtual List<Artist> Artists
        {
            get { return _artists ?? (new List<Artist>()); }
            set { _artists = value; }
        }

        public virtual List<Genre> Genres
        {
            get { return _genres ?? (new List<Genre>()); }
            set { _genres = value; }
        }

        public virtual List<Song> Songs
        {
            get { return _songs ?? (new List<Song>()); }
            set { _songs = value; }
        }

        public bool Equals(AlbumArtist albumArtist)
        {
            return Title.Equals(albumArtist.Title);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}