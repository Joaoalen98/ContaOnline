using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    [Authorize]
    public class ContaCorrenteController : Controller
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteController()
        {
            _contaCorrenteRepository = AppHelper.ObterContaCorrenteRepository();
        }

        public ActionResult Inicio()
        {
            var lista = _contaCorrenteRepository.ObterTodos(User.FindFirst("Id")!.Value);
            return View(lista);
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ContaCorrenteViewModel model)
        {
            if (string.IsNullOrEmpty(model.Descricao))
            {
                ModelState.AddModelError("", "A descrição deve ser informada");
            }
            else if (ModelState.IsValid)
            {
                var contaCorrente = new ContaCorrente
                {
                    Id = Guid.NewGuid().ToString(),
                    UsuarioId = User.FindFirst("Id")!.Value,
                    Descricao = model.Descricao
                };
                _contaCorrenteRepository.Incluir(contaCorrente);

                return RedirectToAction("Inicio");
            }

            return View(model);
        }

        public ActionResult Alterar(string id)
        {
            var contaCorrente = _contaCorrenteRepository.ObterPorId(id);
            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Alterar(ContaCorrente model)
        {
            if (ModelState.IsValid)
            {
                _contaCorrenteRepository.Alterar(model);
                return RedirectToAction("Inicio");
            }
            return RedirectToAction("Inicio");
        }

        public ActionResult Excluir(string id)
        {
            var contaCorrente = _contaCorrenteRepository.ObterPorId(id);
            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Excluir(IFormCollection form, string id)
        {
            _contaCorrenteRepository.Excluir(id);
            return RedirectToAction("Inicio");
        }
    }
}