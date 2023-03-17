using ContaOnline.Domain.Interfaces;
using ContaOnline.Repository;
using ContaOnline.UI.Web.Models;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{

    public class AppController : Controller
    {

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