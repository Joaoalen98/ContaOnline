using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
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
    }
}