using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class User : IEquatable<User>
    {
        private List<Playlist> _playlists;

        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public virtual List<Playlist> Playlists
        {
            get { return _playlists ?? (new List<Playlist>()); }
            set { _playlists = value; }
        }

        public bool Equals(User user)
        {
            return Name.Equals(user.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}