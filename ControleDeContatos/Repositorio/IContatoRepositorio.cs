using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {

        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos(int usuarioId);
        public ContatoModel Adicionar(ContatoModel contato);
        public ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
