using ContaOnline.Domain.Enums;
using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using System;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly Usuario _usuario;

        public ContatoController()
        {
            _contatoRepository = AppHelper.ObterContatoRepository();
            _usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Incluir()
        {
            var contatoViewModel = new ContatoViewModel();
            return View(contatoViewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contato contato;
                if (model.Tipo == TipoPessoa.PessoaFisica)
                {
                    contato = new Pessoa();
                    ((Pessoa)contato).RG = model.RG;
                    ((Pessoa)contato).CPF = model.CPF;
                    ((Pessoa)contato).DataNascimento = model.DataNascimento;
                }
                else
                {
                    contato = new Empresa();
                    ((Empresa)contato).CNPJ = model.CNPJ;
                }

                contato.Id = Guid.NewGuid().ToString();
                contato.Nome = model.Nome;
                contato.Telefone = model.Telefone;
                contato.Email = model.Email;
                contato.UsuarioId = _usuario.Id;
                contato.Tipo = model.Tipo;

                _contatoRepository.Incluir(contato);
                return RedirectToAction("Inicio");
            }
            return View(model);
        }
    }
}