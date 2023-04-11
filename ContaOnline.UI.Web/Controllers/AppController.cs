using ContaOnline.Domain.Interfaces;
using ContaOnline.UI.Web.Models;
using ContaOnline.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace ContaOnline.UI.Web.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Registro()
        {
            var registro = new RegistroViewModel();
            return View(registro);
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "O email deve ser informado");
            }

            if (string.IsNullOrEmpty(model.Senha))
            {
                ModelState.AddModelError("", "A senha deve ser informada");
            }
            else
            {
                if (model.Senha != model.ConfirmarSenha)
                {
                    ModelState.AddModelError("", "As senhas não conferem.");
                }
            }

            if (ModelState.IsValid)
            {
                var usuario = new Usuario()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = model.Email,
                    Senha = model.Senha,
                    Nome = model.Nome
                };
                
                var usuarioRepo = AppHelper.ObterUsuarioRepository();
                usuarioRepo.Incluir(usuario);
                
                HttpContext.SignInAsync(AppHelper.ObterClaimsPrincipalUsuario(usuario));
                
                return RedirectToAction("Inicio");
            }
            else
            {
                return View(model);
            }
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
                HttpContext.SignInAsync(AppHelper.ObterClaimsPrincipalUsuario(usuario));
                return RedirectToAction("Inicio");
            }

            return View(model);
        }

        /// <summary>
        /// Tela inicial
        /// </summary>
        /// <returns></returns>
        [Authorize]
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