using System.Collections.Generic;
using System.Linq;
using PsyTrance.DataLayer;
using PsyTrance.DataLayer.Models;

namespace PsyTrance
{
    public class Program
    {
        private static IUnitOfWork _unitOfWork;

        private static void Main()
        {
            _unitOfWork = new UnitOfWork();

            Directory(@"C:\Albums");

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

                
























                //_albumArtists
                //    .Intersect(albumArtists)
                //    .ToList()
                //    .ForEach(albumArtist => albumArtist.Albums.AddRange(_albums.Intersect(albums).Except(albumArtist.Albums).ToList()));

                //_albumArtists
                //    .Intersect(albumArtists)
                //    .ToList()
                //    .ForEach(albumArtist => albumArtist.Artists.AddRange(_artists.Intersect(artists).Except(albumArtist.Artists).ToList()));

                //_albumArtists
                //    .Intersect(albumArtists)
                //    .ToList()
                //    .ForEach(albumArtist => albumArtist.Genres.AddRange(_genres.Intersect(genres).Except(albumArtist.Genres).ToList()));

                //_albumArtists
                //    .Intersect(albumArtists)
                //    .ToList()
                //    .ForEach(albumArtist => albumArtist.Songs.AddRange(_songs.Intersect(songs).Except(albumArtist.Songs).ToList()));

                //_albumArtists
                //    .Intersect(albumArtists)
                //    .ToList()
                //    .ForEach(albumArtist => _unitOfWork.AlbumArtistsRepository.Insert(albumArtist));



                //_albums
                //    .Intersect(albums)
                //    .ToList()
                //    .ForEach(album => album.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(album.AlbumArtists).ToList()));

                //_albums
                //    .Intersect(albums)
                //    .ToList()
                //    .ForEach(album => album.Artists.AddRange(_artists.Intersect(artists).Except(album.Artists).ToList()));

                //_albums
                //    .Intersect(albums)
                //    .ToList()
                //    .ForEach(album => album.Genres.AddRange(_genres.Intersect(genres).Except(album.Genres).ToList()));

                //_albums
                //    .Intersect(albums)
                //    .ToList()
                //    .ForEach(album => album.Songs.AddRange(_songs.Intersect(songs).Except(album.Songs).ToList()));

                //_albums
                //    .Intersect(albums)
                //    .ToList()
                //    .ForEach(album => _unitOfWork.AlbumsRepository.Insert(album));



                //_artists
                //    .Intersect(artists)
                //    .ToList()
                //    .ForEach(artist => artist.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(artist.AlbumArtists).ToList()));

                //_artists
                //    .Intersect(artists)
                //    .ToList()
                //    .ForEach(artist => artist.Albums.AddRange(_albums.Intersect(albums).Except(artist.Albums).ToList()));

                //_artists
                //    .Intersect(artists)
                //    .ToList()
                //    .ForEach(artist => artist.Genres.AddRange(_genres.Intersect(genres).Except(artist.Genres).ToList()));

                //_artists
                //    .Intersect(artists)
                //    .ToList()
                //    .ForEach(artist => artist.Songs.AddRange(_songs.Intersect(songs).Except(artist.Songs).ToList()));

                //_artists
                //    .Intersect(artists)
                //    .ToList()
                //    .ForEach(artist => _unitOfWork.ArtistsRepository.Insert(artist));



                //_genres
                //    .Intersect(genres)
                //    .ToList()
                //    .ForEach(genre => genre.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(genre.AlbumArtists).ToList()));

                //_genres
                //    .Intersect(genres)
                //    .ToList()
                //    .ForEach(genre => genre.Albums.AddRange(_albums.Intersect(albums).Except(genre.Albums).ToList()));

                //_genres
                //    .Intersect(genres)
                //    .ToList()
                //    .ForEach(genre => genre.Artists.AddRange(_artists.Intersect(artists).Except(genre.Artists).ToList()));

                //_genres
                //    .Intersect(genres)
                //    .ToList()
                //    .ForEach(genre => genre.Songs.AddRange(_songs.Intersect(songs).Except(genre.Songs).ToList()));

                //_genres
                //    .Intersect(genres)
                //    .ToList()
                //    .ForEach(genre => _unitOfWork.GenresRepository.Insert(genre));



                //_songs
                //    .Intersect(songs)
                //    .ToList()
                //    .ForEach(song => song.AlbumArtists.AddRange(_albumArtists.Intersect(albumArtists).Except(song.AlbumArtists).ToList()));

                //_songs
                //    .Intersect(songs)
                //    .ToList()
                //    .ForEach(song => song.Albums.AddRange(_albums.Intersect(albums).Except(song.Albums).ToList()));

                //_songs
                //    .Intersect(songs)
                //    .ToList()
                //    .ForEach(song => song.Artists.AddRange(_artists.Intersect(artists).Except(song.Artists).ToList()));

                //_songs
                //    .Intersect(songs)
                //    .ToList()
                //    .ForEach(song => song.Genres.AddRange(_genres.Intersect(genres).Except(song.Genres).ToList()));

                //_songs
                //    .Intersect(songs)
                //    .ToList()
                //    .ForEach(song => _unitOfWork.SongsRepository.Insert(song));
            }
        }
    }
}