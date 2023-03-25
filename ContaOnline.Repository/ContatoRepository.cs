using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System.Collections.Generic;

namespace ContaOnline.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        public void Alterar(Contato entidade)
        {
            Db.Executar("ContatoAlterar", entidade);
        }

        public void Excluir(string id)
        {
            Db.Executar("ContatoExcluir", new { Id = id });
        }

        public void Incluir(Contato entidade)
        {
            if (entidade is Empresa)
            {
                Db.Executar("ContatoEmpresaIncluir", entidade);
            }
            else
            {
                Db.Executar("ContatoPessoaIncluir", entidade);
            }
        }

        public Contato ObterPorId(string id)
        {
            return Db.QueryEntidade<Contato>("ContatoObterPorId", new { Id = id });
        }

        public IEnumerable<Contato> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Contato>("ContatoObterTodos", new { UsuarioId = usuarioId });
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
