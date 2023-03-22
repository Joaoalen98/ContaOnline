using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using System.Web;

namespace ContaOnline.UI.Web
{
    public static class AppHelper
    {
        public static UsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }

        public static void RegistrarUsuarioSessao(Usuario usuario)
        {
            HttpContext.Current.Session["usuario"] = usuario;
        }

        public static Usuario ObterUsuarioLogado()
        {
            return (Usuario)HttpContext.Current.Session["usuario"];
        }

        public static ContaCorrenteRepository ObterContaCorrenteRepository()
        {
            return new ContaCorrenteRepository();
        }

        public static ContaCategoriaRepository ObterContaCategoriaRepository()
        {
            return new ContaCategoriaRepository();
        }

        public static ContatoRepository ObterContatoRepository()
        {
            return new ContatoRepository();
        }

        public static ContaRepository ObterContaRepository()
        {
            return new ContaRepository();
        }
    }
}