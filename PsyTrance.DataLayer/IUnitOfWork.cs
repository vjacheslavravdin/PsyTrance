using System;
using PsyTrance.DataLayer.Models;

namespace PsyTrance.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<AlbumArtist> AlbumArtistsRepository { get; }
        Repository<Album> AlbumsRepository { get; }
        Repository<Artist> ArtistsRepository { get; }
        Repository<Genre> GenresRepository { get; }
        Repository<Song> SongsRepository { get; }

        void SaveChanges();
    }
}