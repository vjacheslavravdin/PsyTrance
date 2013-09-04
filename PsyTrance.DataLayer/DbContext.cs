using PsyTrance.DataLayer.Models;

namespace PsyTrance.DataLayer
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<AlbumArtist> AlbumArtists;
        public System.Data.Entity.DbSet<Album> Albums;
        public System.Data.Entity.DbSet<Artist> Artists;
        public System.Data.Entity.DbSet<Genre> Genres;
        public System.Data.Entity.DbSet<Song> Songs;

        public DbContext()
            : base("")
        {
        }
    }
}