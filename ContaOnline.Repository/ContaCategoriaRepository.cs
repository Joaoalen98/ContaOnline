using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ContaOnline.Repository
{
    public class ContaCategoriaRepository : IContaCategoriaRepository
    {
        public void Alterar(ContaCategoria entidade)
        {
            Db.Executar("ContaCategoriaAlterar", entidade, CommandType.StoredProcedure);
        }

        public void Excluir(string id)
        {
            Db.Executar("ContaCategoriaExcluir", new { Id = id}, CommandType.StoredProcedure);
        }

        public void Incluir(ContaCategoria entidade)
        {
            Db.Executar("ContaCategoriaIncluir", entidade, CommandType.StoredProcedure);
        }

        public ContaCategoria ObterPorId(string id)
        {
            return Db.QueryEntidade<ContaCategoria>("ContaCategoriaObterPorId", new { Id = id}, CommandType.StoredProcedure);
        }

        public IEnumerable<ContaCategoria> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<ContaCategoria>("ContaCategoriaObterTodos", null, CommandType.StoredProcedure);
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
