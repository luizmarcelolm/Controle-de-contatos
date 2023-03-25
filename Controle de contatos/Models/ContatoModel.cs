﻿using System.ComponentModel.DataAnnotations;

namespace Controle_de_contatos.Models
{
    public class ContatoModel
    {
       public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "Celular inválido!")]
        public string Celular { get; set; }
    }
}
