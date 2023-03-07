using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class AppController : Controller
    {

        /// <summary>
        /// Tela inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Inicio()
        {
            return View();
        }


        /// <summary>
        /// Registro de usuário
        /// </summary>
        /// <returns></returns>
        public ActionResult Registro()
        {
            return View();
        }


        /// <summary>
        /// Sobre o App
        /// </summary>
        /// <returns></returns>
        public ActionResult Sobre()
        {
            return View();
        }
    }
}