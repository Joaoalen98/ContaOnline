using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;

namespace ContaOnline.Repository
{
    public class ContaRepository : IContaRepository
    {
        public void Alterar(Conta entidade)
        {
            Db.Executar("ContaAlterar", entidade);
        }

        public void Excluir(string id)
        {
            Db.Executar("ContaExcluir", new { Id = id });
        }

        public void Incluir(Conta entidade)
        {
            Db.Executar("ContaIncluir", entidade);
        }

        public IEnumerable<Conta> ObterPorFiltro(ContaFiltro filtro)
        {
            throw new NotImplementedException();
        }

        public Conta ObterPorId(string id)
        {
            return Db.QueryEntidade<Conta>("ContaObterPorId", new { Id = id });
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Conta>("ContaObterTodas", new { UsuarioId = usuarioId });
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
