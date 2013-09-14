using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsyTrance.DataLayer;

namespace PsyTrance.PresentationLayer.Controllers
{
    public class ArtistController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
