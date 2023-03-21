using Controle_de_contatos.Models;

namespace Controle_de_contatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}
