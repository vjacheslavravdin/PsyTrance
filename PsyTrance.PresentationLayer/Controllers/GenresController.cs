using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsyTrance.DataLayer;

namespace PsyTrance.PresentationLayer.Controllers
{
    public class GenresController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenresController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        ~GenresController()
        {
            _unitOfWork.Dispose();
        }
    }
}