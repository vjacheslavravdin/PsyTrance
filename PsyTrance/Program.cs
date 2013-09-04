using System;
using System.Collections.Generic;
using System.Linq;
using PsyTrance.DataLayer;
using PsyTrance.DataLayer.Models;
using TagLib;

namespace PsyTrance
{
    internal class Program
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

            _albumArtists = _unitOfWork.AlbumArtistsRepository.Select().ToList();
            _albums = _unitOfWork.AlbumsRepository.Select().ToList();
            _artists = _unitOfWork.ArtistsRepository.Select().ToList();
            _genres = _unitOfWork.GenresRepository.Select().ToList();
            _songs = _unitOfWork.SongsRepository.Select().ToList();

            Directory(@"C:\Albums");

            foreach (var artist in _artists)
            {
                Console.WriteLine("--" + artist.Title);
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine("----" + album.Title);
                }
            }

            Console.ReadLine();
        }

        private static void Directory(string path)
        {
            try
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
            catch (Exception exception)
            {
            }
        }

        private static void File(string path)
        {
            try
            {
                using (var file = TagLib.File.Create(path))
                {
                    var albumArtists = file.Tag.AlbumArtists.Select(x => new AlbumArtist
                    {
                        Title = x
                    }).ToList();

                    _albumArtists = _albumArtists.Union(albumArtists).ToList();

                    var albums = new List<Album>
                    {
                        new Album
                        {
                            Title = file.Tag.Album
                        }
                    };

                    _albums = _albums.Union(albums).ToList();

                    var artists = file.Tag.Performers.Select(x => new Artist
                    {
                        Title = x
                    }).ToList();

                    _artists = _artists.Union(artists).ToList();

                    var genres = file.Tag.Genres.Select(x => new Genre
                    {
                        Title = x
                    }).ToList();

                    _genres = _genres.Union(genres).ToList();

                    var songs = new List<Song>
                    {
                        new Song
                        {
                            Title = file.Tag.Title
                        }
                    };

                    _songs = _songs.Union(songs).ToList();

                    _albumArtists.Intersect(albumArtists)
                        .ToList()
                        .ForEach(delegate(AlbumArtist albumArtist)
                        {
                            albumArtist.Albums.AddRange(
                                _albums.Intersect(albums).Except(albumArtist.Albums).ToList());

                            albumArtist.Artists.AddRange(
                                _artists.Intersect(artists).Except(albumArtist.Artists).ToList());

                            albumArtist.Genres.AddRange(
                                _genres.Intersect(genres).Except(albumArtist.Genres).ToList());

                            albumArtist.Songs.AddRange(
                                _songs.Intersect(songs).Except(albumArtist.Songs).ToList());
                        });
                }
            }
            catch (Exception exception)
            {
            }
        }
    }
}