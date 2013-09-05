using System;
using System.Collections.Generic;
using System.Linq;
using PsyTrance.DataLayer;
using PsyTrance.DataLayer.Models;

namespace PsyTrance
{
    public class Program
    {
        private static IUnitOfWork _unitOfWork;

        private static List<AlbumArtist> _albumArtists;
        private static List<Album> _albums;
        private static List<Artist> _artists;
        private static List<Genre> _genres;
        private static List<Song> _songs;

        private static void Main()
        {
            _unitOfWork = new UnitOfWork();

            _albumArtists = _unitOfWork.AlbumArtistsRepository.Select();
            _albums = _unitOfWork.AlbumsRepository.Select();
            _artists = _unitOfWork.ArtistsRepository.Select();
            _genres = _unitOfWork.GenresRepository.Select();
            _songs = _unitOfWork.SongsRepository.Select();

            Directory(@"C:\Albums");

            _albumArtists.ForEach(delegate(AlbumArtist albumArtist)
            {
                if (albumArtist.Id == 0)
                {
                    _unitOfWork.AlbumArtistsRepository.Insert(albumArtist);
                }
                else
                {
                    _unitOfWork.AlbumArtistsRepository.Update(albumArtist);
                }
            });

            _albums.ForEach(delegate(Album album)
            {
                if (album.Id == 0)
                {
                    _unitOfWork.AlbumsRepository.Insert(album);
                }
                else
                {
                    _unitOfWork.AlbumsRepository.Update(album);
                }
            });

            _artists.ForEach(delegate(Artist artist)
            {
                if (artist.Id == 0)
                {
                    _unitOfWork.ArtistsRepository.Insert(artist);
                }
                else
                {
                    _unitOfWork.ArtistsRepository.Update(artist);
                }
            });

            _genres.ForEach(delegate(Genre genre)
            {
                if (genre.Id == 0)
                {
                    _unitOfWork.GenresRepository.Insert(genre);
                }
                else
                {
                    _unitOfWork.GenresRepository.Update(genre);
                }
            });

            _songs.ForEach(delegate(Song song)
            {
                if (song.Id == 0)
                {
                    _unitOfWork.SongsRepository.Insert(song);
                }
                else
                {
                    _unitOfWork.SongsRepository.Update(song);
                }
            });

            _unitOfWork.SaveChanges();

            _unitOfWork.Dispose();
        }

        private static void Directory(string path)
        {
            var directories = new List<string>(System.IO.Directory.EnumerateDirectories(path));

            foreach (var directory in directories)
            {
                Directory(directory);
            }

            var files = new List<string>(System.IO.Directory.EnumerateFiles(path));

            foreach (var file in files)
            {
                File(file);
            }
        }

        private static void File(string path)
        {
            using (var file = TagLib.File.Create(path))
            {
                var albumArtists = file.Tag.AlbumArtists.Select(title => new AlbumArtist
                {
                    Title = title,
                    Albums = new List<Album>(),
                    Artists = new List<Artist>(),
                    Genres = new List<Genre>(),
                    Songs = new List<Song>()
                }).ToList();

                var albums = new List<Album>
                {
                    new Album
                    {
                        Title = file.Tag.Album,
                        AlbumArtists = new List<AlbumArtist>(),
                        Artists = new List<Artist>(),
                        Genres = new List<Genre>(),
                        Songs = new List<Song>()
                    }
                };

                var artists = file.Tag.Performers.Select(title => new Artist
                {
                    Title = title,
                    AlbumArtists = new List<AlbumArtist>(),
                    Albums = new List<Album>(),
                    Genres = new List<Genre>(),
                    Songs = new List<Song>()
                }).ToList();

                var genres = file.Tag.Genres.Select(title => new Genre
                {
                    Title = title,
                    AlbumArtists = new List<AlbumArtist>(),
                    Albums = new List<Album>(),
                    Artists = new List<Artist>(),
                    Songs = new List<Song>()
                }).ToList();

                var songs = new List<Song>
                {
                    new Song
                    {
                        Title = file.Tag.Title,
                        AlbumArtists = new List<AlbumArtist>(),
                        Albums = new List<Album>(),
                        Artists = new List<Artist>(),
                        Genres = new List<Genre>()
                    }
                };

                _albumArtists = _albumArtists.Union(albumArtists).ToList();
                _albums = _albums.Union(albums).ToList();
                _artists = _artists.Union(artists).ToList();
                _genres = _genres.Union(genres).ToList();
                _songs = _songs.Union(songs).ToList();

                _albumArtists.Intersect(albumArtists).ToList().ForEach(delegate(AlbumArtist albumArtist)
                {
                    albumArtist.Albums.AddRange(_albums.Intersect(albums).Except(albumArtist.Albums).ToList());
                    albumArtist.Artists.AddRange(_artists.Intersect(artists).Except(albumArtist.Artists).ToList());
                    albumArtist.Genres.AddRange(_genres.Intersect(genres).Except(albumArtist.Genres).ToList());
                    albumArtist.Songs.AddRange(_songs.Intersect(songs).Except(albumArtist.Songs).ToList());
                });

                _albums.Intersect(albums).ToList().ForEach(delegate(Album album)
                {
                    album.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(album.AlbumArtists).ToList());
                    album.Artists.AddRange(_artists.Intersect(artists).Except(album.Artists).ToList());
                    album.Genres.AddRange(_genres.Intersect(genres).Except(album.Genres).ToList());
                    album.Songs.AddRange(_songs.Intersect(songs).Except(album.Songs).ToList());
                });

                _artists.Intersect(artists).ToList().ForEach(delegate(Artist artist)
                {
                    artist.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(artist.AlbumArtists).ToList());
                    artist.Albums.AddRange(_albums.Intersect(albums).Except(artist.Albums).ToList());
                    artist.Genres.AddRange(_genres.Intersect(genres).Except(artist.Genres).ToList());
                    artist.Songs.AddRange(_songs.Intersect(songs).Except(artist.Songs).ToList());
                });

                _genres.Intersect(genres).ToList().ForEach(delegate(Genre genre)
                {
                    genre.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(genre.AlbumArtists).ToList());
                    genre.Albums.AddRange(_albums.Intersect(albums).Except(genre.Albums).ToList());
                    genre.Artists.AddRange(_artists.Intersect(artists).Except(genre.Artists).ToList());
                    genre.Songs.AddRange(_songs.Intersect(songs).Except(genre.Songs).ToList());
                });

                _songs.Intersect(songs).ToList().ForEach(delegate(Song song)
                {
                    song.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(song.AlbumArtists).ToList());
                    song.Albums.AddRange(_albums.Intersect(albums).Except(song.Albums).ToList());
                    song.Artists.AddRange(_artists.Intersect(artists).Except(song.Artists).ToList());
                    song.Genres.AddRange(_genres.Intersect(genres).Except(song.Genres).ToList());
                });
            }
        }
    }
}