using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContaOnline.UI.Web.Controllers
{
    [Authorize]
    public class ContaCategoriaController : Controller
    {
        private readonly IContaCategoriaRepository _contaCategoriaRepository;

        public ContaCategoriaController()
        {
            _contaCategoriaRepository = AppHelper.ObterContaCategoriaRepository();
        }


        public ActionResult Inicio()
        {
            var lista = _contaCategoriaRepository.ObterTodos(User.FindFirst("Id")!.Value);
            return View(lista);
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ContaCategoriaViewModel model)
        {
            if (string.IsNullOrEmpty(model.Nome))
            {
                ModelState.AddModelError("", "O nome deve ser informada");
            }
            else if (ModelState.IsValid)
            {
                var contaCategoria = new ContaCategoria
                {
                    Id = Guid.NewGuid().ToString(),
                    UsuarioId = User.FindFirst("Id")!.Value,
                    Nome = model.Nome
                };
                _contaCategoriaRepository.Incluir(contaCategoria);

                return RedirectToAction("Inicio");
            }

            return View(model);
        }

        public ActionResult Alterar(string id)
        {
            var contaCategoria = _contaCategoriaRepository.ObterPorId(id);
            return View(contaCategoria);
        }

        [HttpPost]
        public ActionResult Alterar(ContaCategoria model)
        {
            if (ModelState.IsValid)
            {
                _contaCategoriaRepository.Alterar(model);
                return RedirectToAction("Inicio");
            }
            return RedirectToAction("Inicio");
        }

        public ActionResult Excluir(string id)
        {
            var contaCorrente = _contaCategoriaRepository.ObterPorId(id);
            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Excluir(IFormCollection form, string id)
        {
            _contaCategoriaRepository.Excluir(id);
            return RedirectToAction("Inicio");
        }
    }
}