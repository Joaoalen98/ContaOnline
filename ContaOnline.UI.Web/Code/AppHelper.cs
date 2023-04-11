using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ContaOnline.UI.Web
{
    public static class AppHelper
    {
        public static UsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }

        public static ClaimsPrincipal ObterClaimsPrincipalUsuario(Usuario usuario)
        {
            var identity = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, usuario.Nome),
                new(ClaimTypes.Email, usuario.Email),
                new("Id", usuario.Id),
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(identity);
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