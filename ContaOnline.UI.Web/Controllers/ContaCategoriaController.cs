using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCategoriaController : Controller
    {
        private readonly IContaCategoriaRepository _contaCategoriaRepository;
        private readonly Usuario _usuario;

        public ContaCategoriaController()
        {
            _contaCategoriaRepository = AppHelper.ObterContaCategoriaRepository();
            _usuario = AppHelper.ObterUsuarioLogado();
        }


        public ActionResult Inicio()
        {
            if (_usuario == null)
            {
                return RedirectToAction("Login", "App");
            }
            var lista = _contaCategoriaRepository.ObterTodos(_usuario.Id);
            return View(lista);
        }

        public ActionResult Incluir()
        {
            var contaCategoria = new ContaCategoria();
            return View(contaCategoria);
        }

        [HttpPost]
        public ActionResult Incluir(ContaCategoria model)
        {
            if (string.IsNullOrEmpty(model.Nome))
            {
                ModelState.AddModelError("", "O nome deve ser informada");
            }
            else if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid().ToString();
                model.UsuarioId = _usuario.Id;
                _contaCategoriaRepository.Incluir(model);

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
        public ActionResult Excluir(FormCollection form, string id)
        {
            _contaCategoriaRepository.Excluir(id);
            return RedirectToAction("Inicio");
        }
    }
}