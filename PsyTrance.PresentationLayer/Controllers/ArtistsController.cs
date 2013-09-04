using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsyTrance.PresentationLayer.Controllers
{
    public class ArtistsController : Controller
    {
        //
        // GET: /Artists/

        public ActionResult Index()
        {
            return View();
        }

    }
}
