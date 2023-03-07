using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContaOnline.Tests
{
    [TestClass]
    public class UsuarioTest
    {
        private Usuario _usuarioMock = new Usuario
        {
            Id = "TesteId",
            Nome = "Nome Teste",
            Email = "teste@teste.com",
            Senha = "SenhaTeste",
        };

        private void PrintUsuario(Usuario usuario)
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"Nome: {usuario.Id}");
            Console.WriteLine($"Nome: {usuario.Nome}");
            Console.WriteLine($"Nome: {usuario.Email}");
            Console.WriteLine($"Nome: {usuario.Senha}");
            Console.WriteLine("-------------");
        }

        [TestMethod]
        public void ValidarNome()
        {
            var usuario = new Usuario()
            {
                Id = "123",
                Email = "teste@teste.com.br",
                Senha = "1231231"
            };

            var erros = usuario.Validar();

            Assert.AreEqual(1, erros.Count, "Deveria retornar um erro");
        }

        [TestMethod]
        public void ValidarSenha()
        {
            var usuario = new Usuario()
            {
                Nome = "Teste",
                Id = "123",
                Email = "teste@teste.com.br",
                Senha = "123"
            };

            var erros = usuario.Validar();

            Assert.AreEqual(1, erros.Count, "Deveria retornar um erro");
            Assert.AreEqual(erros[0], "A senha deve conter 5 caracteres no mínimo", "Retornando mensagem errada");
        }

        [TestMethod]
        public void IncluirTest()
        {
            try
            {
                var rep = new UsuarioRepository();
                rep.Incluir(_usuarioMock);
            }
            catch (Exception ex)
            {
                Assert.Fail($"O método retornou uma excessão - {ex.Message}");
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            try
            {
                var rep = new UsuarioRepository();
                var usuario = rep.ObterPorId(_usuarioMock.Id);
                
                PrintUsuario(usuario);
            }
            catch (Exception ex)
            {
                Assert.Fail($"O metodo retornou uma excessão - {ex.Message}");
            }
        }

        [TestMethod]
        public void ObterPorEmailSenhaTest()
        {
            try
            {
                var rep = new UsuarioRepository();
                var usuario = rep.ObterPorEmailSenha(_usuarioMock.Email, _usuarioMock.Senha);

                PrintUsuario(usuario);
            }
            catch (Exception ex)
            {
                Assert.Fail($"O metodo retornou uma excessão - {ex.Message}");
            }
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            try
            {
                var rep = new UsuarioRepository();
                var lista = rep.ObterTodos(null);

                foreach (var usuario in lista)
                {
                    PrintUsuario(usuario);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"O metodo retornou uma excessão - {ex.Message}");
            }
        }

        [TestMethod]
        public void AlterarTest()
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = _usuarioMock.Id,
                    Nome = "Nome Teste Alterado",
                };

                var rep = new UsuarioRepository();
                rep.Alterar(usuario);

                var usuarioAlterado = rep.ObterPorId(_usuarioMock.Id);
                if (usuarioAlterado.Nome != "Nome Teste Alterado")
                {
                    Assert.Fail("O nome do usuário teste não foi alterado");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"O metodo retornou uma excessão - {ex.Message}");
            }
        }

        [TestMethod]
        public void ExcluirTest()
        {
            try
            {
                var rep = new UsuarioRepository();
                rep.Excluir(_usuarioMock.Id);

                var usuario = rep.ObterPorId(_usuarioMock.Id);

                if (usuario != null)
                {
                    Assert.Fail("O usuário não foi excluido");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"O metodo retornou uma excessão - {ex.Message}");
            }
        }
    }
}
