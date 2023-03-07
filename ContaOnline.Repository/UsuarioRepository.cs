using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ContaOnline.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(Usuario entidade)
        {
            Db.Executar("UsuarioAlterar", entidade, CommandType.StoredProcedure);
        }

        public void Excluir(string id)
        {
            Db.Executar("UsuarioExcluir", new { Id = id }, CommandType.StoredProcedure);
        }

        public void Incluir(Usuario entidade)
        {
            Db.Executar("UsuarioIncluir", entidade, CommandType.StoredProcedure);
        }

        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            return Db.QueryEntidade<Usuario>("UsuarioObterPorEmailSenha", new { Email = email, Senha = senha }, CommandType.StoredProcedure);   
        }

        public Usuario ObterPorId(string id)
        {
            return Db.QueryEntidade<Usuario>("UsuarioObterPorId", new { Id = id }, CommandType.StoredProcedure);
        }

        public IEnumerable<Usuario> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Usuario>("UsuarioObterTodos", null, CommandType.StoredProcedure);
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
