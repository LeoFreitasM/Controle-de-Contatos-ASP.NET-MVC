using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;


public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
             usuario.DataCadastro = DateTime.Now;
             usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

    public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
    {
        UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

        if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado.");

        if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

        if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual.");

        usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
        usuarioDB.DataAtualizacao = DateTime.Now;

        _bancoContext.Usuarios.Update(usuarioDB);
        _bancoContext.SaveChanges();

        return usuarioDB;
    }

    public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new SystemException("Houve um erro na deleção do usuário!");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
             UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new SystemException("Houve um erro na atualização do usuário!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

    public UsuarioModel BuscarPorEmaileLogin(string email, string login)
    {
        return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
    }

    public UsuarioModel BuscarPorLogin(string login)
    {
        //retornar o primeiro ou o único registro que existe dentro do banco onde o Login for igual ao login
        return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
    }

    public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios
            .Include(x => x.Contatos)
            .ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

}
