using System;
using PsyTrance.DataLayer.Models;

namespace PsyTrance.DataLayer
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;

        private Repository<AlbumArtist> _albumArtistsRepository;
        private Repository<Album> _albumsRepository;
        private Repository<Artist> _artistsRepository;
        private Repository<Genre> _genresRepository;
        private Repository<Song> _songsRepository;

        public UnitOfWork()
        {
            _dbContext = new DbContext();
        }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Repository<AlbumArtist> AlbumArtistsRepository
        {
            get { return _albumArtistsRepository ?? (_albumArtistsRepository = new Repository<AlbumArtist>(_dbContext)); }
        }

        public Repository<Album> AlbumsRepository
        {
            get { return _albumsRepository ?? (_albumsRepository = new Repository<Album>(_dbContext)); }
        }

        public Repository<Artist> ArtistsRepository
        {
            get { return _artistsRepository ?? (_artistsRepository = new Repository<Artist>(_dbContext)); }
        }

        public Repository<Genre> GenresRepository
        {
            get { return _genresRepository ?? (_genresRepository = new Repository<Genre>(_dbContext)); }
        }

        public Repository<Song> SongsRepository
        {
            get { return _songsRepository ?? (_songsRepository = new Repository<Song>(_dbContext)); }
        }

        public void Dispose()
        {
        }
    }
}