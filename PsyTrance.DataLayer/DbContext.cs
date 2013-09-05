using PsyTrance.DataLayer.Models;

namespace PsyTrance.DataLayer
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("DbContext")
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        public System.Data.Entity.DbSet<AlbumArtist> AlbumArtistsDbSet { get; set; }
        public System.Data.Entity.DbSet<Album> AlbumsDbSet { get; set; }
        public System.Data.Entity.DbSet<Artist> ArtistsDbSet { get; set; }
        public System.Data.Entity.DbSet<Genre> GenresDbSet { get; set; }
        public System.Data.Entity.DbSet<Song> SongsDbSet { get; set; }
    }
}