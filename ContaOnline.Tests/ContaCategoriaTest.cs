using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContaOnline.Tests
{
    [TestClass]
    public class ContaCategoriaTest
    {
        private readonly ContaCategoria _contaCategoria = new ContaCategoria
        {
            Id = "IdTeste",
            Nome = "Nome Teste",
            UsuarioId = "IdUsuarioTeste"
        };

        [TestMethod]
        public void IncluirTest()
        {
            var rep = new ContaCategoriaRepository();
            rep.Incluir(_contaCategoria);
        }

        [TestMethod]
        public void AlterarTest()
        {
            var rep = new ContaCategoriaRepository();
            var contaCategoria = new ContaCategoria
            {
                Id = _contaCategoria.Id,
                Nome = "Nome Teste Alterado",
                UsuarioId = _contaCategoria.UsuarioId,
            };
            rep.Alterar(contaCategoria);
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var rep = new ContaCategoriaRepository();
            var lista = rep.ObterTodos(null);

            foreach (var categoria in lista)
            {
                Console.WriteLine($"Nome: {categoria.Nome}");
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var rep = new ContaCategoriaRepository();
            var categoria = rep.ObterPorId(_contaCategoria.Id);
            Console.WriteLine($"Nome: {categoria.Nome}");
        }

        [TestMethod]
        public void DeletarTest()
        {
            var rep = new ContaCategoriaRepository();
            rep.Excluir(_contaCategoria.Id);
        }
    }
}
