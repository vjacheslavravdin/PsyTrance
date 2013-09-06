using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PsyTrance.DataLayer;

namespace PsyTrance.PresentationLayer.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Select(int genreId)
        {
            var json = JsonConvert.SerializeObject(product);

            return json;
        }

        ~GenreController()
        {
            _unitOfWork.Dispose();
        }
    }
}
