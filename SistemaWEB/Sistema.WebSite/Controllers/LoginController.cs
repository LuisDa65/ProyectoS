using Sistema.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sistema.WebSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BL.PermisosHandler permisos = new BL.PermisosHandler();
                    TL.Usuario usuario = new TL.Usuario();
                    usuario.Correo = login.Correo;
                    usuario.Contraseña = login.Password;

                    TL.Usuario Sesion = permisos.IniSesion(usuario);

                    if (Sesion != null)
                    {
                        FormsAuthentication.SetAuthCookie(login.Password, false);
                        Session["Usuario"] =Sesion;
                        return RedirectToAction("Index", "Principal");
                    }
                    else 
                    {
                        return View();
                    }

                    
                }
                catch (Exception)
                {

                    return View();
                }
               
            }
            else
            {
                return View();
            }
        }
    }
}