﻿using ContaOnline.Domain.Enums;
using System;

namespace ContaOnline.UI.Web.Models
{
    public class ContatoViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public TipoPessoa Tipo { get; set; }

        public string CNPJ { get; set; }

        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}