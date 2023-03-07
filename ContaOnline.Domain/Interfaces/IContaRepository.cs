using ContaOnline.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace ContaOnline.Domain.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        IEnumerable<Conta> ObterPorFiltro(ContaFiltro filtro);
    }
}
