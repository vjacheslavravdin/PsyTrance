using System;
using System.Collections.Generic;

namespace PsyTrance.DataLayer.Models
{
    public class User : IEquatable<User>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Playlist> Playlists { get; set; }

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