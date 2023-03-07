using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContaOnline.Tests
{
    [TestClass]
    public class ContaCorrenteTest
    {
        private readonly ContaCorrente _contaCorrenteMock = new ContaCorrente
        {
            Id = "IdTeste",
            Descricao = "Descriçao Teste",
            UsuarioId = "UsuarioIdTeste",
        };

        [TestMethod]
        public void IncluirTest()
        {
            var rep = new ContaCorrenteRepository();
            rep.Incluir(_contaCorrenteMock);
        }

        [TestMethod]
        public void AlterarTest()
        {
            var rep = new ContaCorrenteRepository();
            var conta = new ContaCorrente
            {
                Id = _contaCorrenteMock.Id,
                Descricao = "Descrição Alterada",
                UsuarioId = _contaCorrenteMock.UsuarioId,
            };
            rep.Alterar(conta);
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var rep = new ContaCorrenteRepository();
            var lista = rep.ObterTodos(_contaCorrenteMock.UsuarioId);

            foreach (var conta in lista)
            {
                Console.WriteLine($"Nome: {conta.Descricao}");
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var rep = new ContaCorrenteRepository();
            var conta = rep.ObterPorId(_contaCorrenteMock.Id);
            Console.WriteLine($"Nome: {conta.Descricao}");
        }

        [TestMethod]
        public void ExcluirTest()
        {
            var rep = new ContaCorrenteRepository();
            rep.Excluir(_contaCorrenteMock.Id);
        }
    }
}
