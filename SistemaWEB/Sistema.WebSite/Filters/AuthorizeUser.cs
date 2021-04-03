using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema.WebSite.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private int IdOperacion = 0;
        private int IdRol = 1;

        public AuthorizeUser(int IdOperacion)
        {
            this.IdOperacion = IdOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            BL.VentasHandler ventas = new BL.VentasHandler();
            bool result = ventas.VerficarPermiso(IdRol, IdOperacion);

            if (result == false)
            {
                filterContext.Result = new RedirectResult("~/Error/Index");
            }
        }

    }
}