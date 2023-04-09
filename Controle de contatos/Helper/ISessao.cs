using Controle_de_contatos.Models;

namespace Controle_de_contatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);

        void RemoverSessaoDoUsuario();

        UsuarioModel BuscarSessaoDoUsuario();

    }
}
