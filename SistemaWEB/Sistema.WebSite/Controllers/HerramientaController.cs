using Sistema.WebSite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema.WebSite.Controllers
{
    [Authorize]
    public class HerramientaController : Controller
    {

        [AuthorizeUser(IdOperacion: 1)]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUser(IdOperacion: 2)]
        public ActionResult Agregar()
        {
            return View();
        }

        [AuthorizeUser(IdOperacion: 3)]
        public ActionResult Editar()
        {
            return View();
        }

        [AuthorizeUser(IdOperacion: 7)]
        public ActionResult Eliminar()
        {
            return View();
        }
    }
}