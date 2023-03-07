using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System.Collections.Generic;

namespace ContaOnline.Repository
{
    public class ContaRepository : IContaRepository
    {
        public void Alterar(Conta entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Conta entidade)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Conta> ObterPorFiltro(ContaFiltro filtro)
        {
            throw new System.NotImplementedException();
        }

        public Conta ObterPorId(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
