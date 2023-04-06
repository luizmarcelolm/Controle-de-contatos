using Controle_de_contatos.Enums;

namespace Controle_de_contatos.Models
{
    public class UsuarioModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        
     }
}
