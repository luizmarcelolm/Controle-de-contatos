using System.ComponentModel.DataAnnotations;
using Controle_de_contatos.Enums;

namespace Controle_de_contatos.Models
{
    public class UsuarioSemSenhaModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
    
     }
}
