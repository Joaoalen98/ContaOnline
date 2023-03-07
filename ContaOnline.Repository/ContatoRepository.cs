using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System.Collections.Generic;

namespace ContaOnline.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        public void Alterar(Contato entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Contato entidade)
        {
            throw new System.NotImplementedException();
        }

        public Contato ObterPorId(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Contato> ObterTodos(string usuarioId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
