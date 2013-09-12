using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsyTrance.DataLayer;
using PsyTrance.DataLayer.Models;
using WebGrease.Css.Extensions;

namespace PsyTrance.ServiceLayer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public void I()
        {
            var directories = System.IO.Directory.EnumerateDirectories("").ToList();

            if (directories.Count > 0)
            {
                foreach (var directory in directories)
                {
                    var files = System.IO.Directory.EnumerateFiles("").ToList();

                    if (files.Count > 0)
                    {
                        using (var unitOfWork = new UnitOfWork())
                        {
                            var albumArtists = unitOfWork.AlbumArtistsRepository.Select();
                            var albums = unitOfWork.AlbumsRepository.Select();
                            var artists = unitOfWork.ArtistsRepository.Select();
                            var genres = unitOfWork.GenresRepository.Select();
                            var songs = unitOfWork.SongsRepository.Select();

                            foreach (var file in files)
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

                                    _albumArtists.Intersect(albumArtists).ToList().ForEach(delegate(AlbumArtist albumArtist)
                                    {
                                        albumArtist.Albums.AddRange(_albums.Intersect(albums).Except(albumArtist.Albums).ToList());
                                        albumArtist.Artists.AddRange(_artists.Intersect(artists).Except(albumArtist.Artists).ToList());
                                        albumArtist.Genres.AddRange(_genres.Intersect(genres).Except(albumArtist.Genres).ToList());
                                        albumArtist.Songs.AddRange(_songs.Intersect(songs).Except(albumArtist.Songs).ToList());
                                    });
                                }
                            }
                        }
                    }
                }
            }
        } 
    }
}