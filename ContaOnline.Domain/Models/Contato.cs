using ContaOnline.Domain.Enums;
using System;

namespace ContaOnline.Domain.Models
{
    public class Contato
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public TipoPessoa Tipo { get; set; }
        public string UsuarioId { get; set; }
    }
}
