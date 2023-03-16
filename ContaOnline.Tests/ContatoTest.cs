using ContaOnline.Domain.Enums;
using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContaOnline.Tests
{
    [TestClass]
    public class ContatoTest
    {
        private readonly Contato _contatoMock = new Contato()
        {
            Id = "IdTeste",
            Email = "teste@teste.com",
            Nome = "Teste",
            Telefone = "11955553333",
            Tipo = TipoPessoa.PessoaFisica,
            UsuarioId = "IdTeste",
        };

        [TestMethod]
        public void IncluirTest()
        {
            var rep = new ContatoRepository();
            rep.Incluir(_contatoMock);
        }

        [TestMethod]
        public void AlterarTest()
        {
            var rep = new ContatoRepository();
            rep.Alterar(_contatoMock);
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var rep = new ContatoRepository();
            var contato = rep.ObterPorId(_contatoMock.Id);

            if (contato != null)
            {
                Console.WriteLine($"Nome: {contato.Nome} - Email: {contato.Email}");
            }
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var rep = new ContatoRepository();
            var contatos = rep.ObterTodos("IdTeste");
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} - Email: {contato.Email}");
            }
        }

        [TestMethod]
        public void DeletarTest()
        {
            var rep = new ContatoRepository();
            rep.Excluir(_contatoMock.Id);
        }
    }
}
