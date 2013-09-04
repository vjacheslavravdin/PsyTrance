using PsyTrance.DataLayer.Models;

namespace PsyTrance.DataLayer
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<AlbumArtist> AlbumArtistsDbSet;
        public System.Data.Entity.DbSet<Album> AlbumsDbSet;
        public System.Data.Entity.DbSet<Artist> ArtistsDbSet;
        public System.Data.Entity.DbSet<Genre> GenresDbSet;
        public System.Data.Entity.DbSet<Song> SongsDbSet;
    }
}