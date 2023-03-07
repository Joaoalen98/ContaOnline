using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ContaOnline.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        public void Alterar(ContaCorrente entidade)
        {
            Db.Executar("ContaCorrenteAlterar", entidade, CommandType.StoredProcedure);
        }

        public void Excluir(string id)
        {
            Db.Executar("ContaCorrenteExcluir", new { Id = id }, CommandType.StoredProcedure);
        }

        public void Incluir(ContaCorrente entidade)
        {
            Db.Executar("ContaCorrenteIncluir", entidade, CommandType.StoredProcedure);
        }

        public ContaCorrente ObterPorId(string id)
        {
            return Db.QueryEntidade<ContaCorrente>("ContaCorrenteObterPorId", 
                new { Id = id }, CommandType.StoredProcedure);
        }

        public IEnumerable<ContaCorrente> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<ContaCorrente>("ContaCorrenteObterTodos", 
                new { UsuarioId = usuarioId }, CommandType.StoredProcedure);
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
