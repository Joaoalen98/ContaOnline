using System.Collections.Generic;

namespace ContaOnline.Domain.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<string> Validar()
        {
            var lista = new List<string>();

            if (string.IsNullOrEmpty(Nome))
            {
                lista.Add("O nome deve ser informado");
            }

            if (string.IsNullOrEmpty(Email))
            {
                lista.Add("O email deve ser informado");
            }

            if (string.IsNullOrEmpty(Senha) || Senha.Length < 5)
            {
                lista.Add("A senha deve conter 5 caracteres no mínimo");
            }

            return lista;
        }
    }
}
