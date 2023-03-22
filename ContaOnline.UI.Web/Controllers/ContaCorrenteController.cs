using System;
using System.Web.Mvc;
using ContaOnline.Domain.Models;
using ContaOnline.Repository;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private readonly ContaCorrenteRepository _contaCorrenteRepository;
        private readonly Usuario _usuario;

        public ContaCorrenteController()
        {
            _contaCorrenteRepository = AppHelper.ObterContaCorrenteRepository();
            _usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Inicio()
        {
            if (_usuario == null)
            {
                return RedirectToAction("Login", "App");
            }
            var lista = _contaCorrenteRepository.ObterTodos(_usuario.Id);
            return View(lista);
        }

        public ActionResult Incluir()
        {
            var contaCorrente = new ContaCorrente();
            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Incluir(ContaCorrente model)
        {
            if (string.IsNullOrEmpty(model.Descricao))
            {
                ModelState.AddModelError("", "A descrição deve ser informada");
            }
            else if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid().ToString();
                model.UsuarioId = _usuario.Id;
                _contaCorrenteRepository.Incluir(model);

                return RedirectToAction("Inicio");
            }

            return View(model);
        }
    }
}