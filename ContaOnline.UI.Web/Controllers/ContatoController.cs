using ContaOnline.Domain.Enums;
using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController()
        {
            _contatoRepository = AppHelper.ObterContatoRepository();
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
                contato.UsuarioId = User.FindFirst("Id")!.Value;
                contato.Tipo = model.Tipo;

                _contatoRepository.Incluir(contato);
                return RedirectToAction("Inicio");
            }
            return View(model);
        }
    }
}