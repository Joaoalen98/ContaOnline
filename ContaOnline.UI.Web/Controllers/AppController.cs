using ContaOnline.Domain.Interfaces;
using ContaOnline.UI.Web.Models;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{

    public class AppController : Controller
    {
        public ActionResult Registro()
        {
            var registro = new RegistroViewModel();
            return View(registro);
        }

        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            IUsuarioRepository rep = AppHelper.ObterUsuarioRepository();
            var usuario = rep.ObterPorEmailSenha(model.Email, model.Senha);
            if (usuario == null)
            {
                model.Mensagem = "Usuario ou senha inexistente";
            }
            else
            {
                AppHelper.RegistrarUsuarioSessao(usuario);
                return RedirectToAction("Inicio");
            }

            return View(model);
        }

        /// <summary>
        /// Tela inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Inicio()
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