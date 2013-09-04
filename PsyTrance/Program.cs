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

            _albumArtists = _unitOfWork.AlbumArtistsRepository.Select().ToList();
            _albums = _unitOfWork.AlbumsRepository.Select().ToList();
            _artists = _unitOfWork.ArtistsRepository.Select().ToList();
            _genres = _unitOfWork.GenresRepository.Select().ToList();
            _songs = _unitOfWork.SongsRepository.Select().ToList();

            Directory(@"C:\Albums");

            Console.Write("Album Artists: ");
            Console.WriteLine(_albumArtists.Count);
            Console.Write("Albums: ");
            Console.WriteLine(_albums.Count);
            Console.Write("Artists: ");
            Console.WriteLine(_artists.Count);
            Console.Write("Genres: ");
            Console.WriteLine(_genres.Count);
            Console.Write("Songs: ");
            Console.WriteLine(_songs.Count);

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
                Console.WriteLine(exception.Message);
            }
        }

        private static void File(string path)
        {
            try
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

                    _albumArtists = _albumArtists.Union(albumArtists).ToList();

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

                    _albums = _albums.Union(albums).ToList();

                    var artists = file.Tag.Performers.Select(title => new Artist
                    {
                        Title = title,
                        AlbumArtists = new List<AlbumArtist>(),
                        Albums = new List<Album>(),
                        Genres = new List<Genre>(),
                        Songs = new List<Song>()
                    }).ToList();

                    _artists = _artists.Union(artists).ToList();

                    var genres = file.Tag.Genres.Select(title => new Genre
                    {
                        Title = title,
                        AlbumArtists = new List<AlbumArtist>(),
                        Albums = new List<Album>(),
                        Artists = new List<Artist>(),
                        Songs = new List<Song>()
                    }).ToList();

                    _genres = _genres.Union(genres).ToList();

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

                    _songs = _songs.Union(songs).ToList();

                    _albumArtists.Intersect(albumArtists)
                        .ToList()
                        .ForEach(albumArtist => albumArtist.Albums.AddRange(_albums.Intersect(albums).Except(albumArtist.Albums).ToList()));

                    _albumArtists.Intersect(albumArtists)
                        .ToList()
                        .ForEach(albumArtist => albumArtist.Artists.AddRange(_artists.Intersect(artists).Except(albumArtist.Artists).ToList()));

                    _albumArtists.Intersect(albumArtists)
                        .ToList()
                        .ForEach(albumArtist => albumArtist.Genres.AddRange(_genres.Intersect(genres).Except(albumArtist.Genres).ToList()));

                    _albumArtists.Intersect(albumArtists)
                        .ToList()
                        .ForEach(albumArtist => albumArtist.Songs.AddRange(_songs.Intersect(songs).Except(albumArtist.Songs).ToList()));

                    _albumArtists.Intersect(albumArtists)
                        .ToList()
                        .ForEach(albumArtist => _unitOfWork.AlbumArtistsRepository.Insert(albumArtist));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}