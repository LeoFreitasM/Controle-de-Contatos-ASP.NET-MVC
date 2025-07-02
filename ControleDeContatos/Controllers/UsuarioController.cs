using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio,
                                 IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario= _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o usuário.";
                }

                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o usuário. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(id);
            return PartialView("_ContatosUsuario", contatos);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o usuário. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Editar(int id)
        {
            //Pegando cada atributo do banco e preenchendo o formulário
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {

            try
            {
                UsuarioModel usuario = null;

                //verificando se a model é válida
                if (ModelState.IsValid)
                {
                   //caso tenha alteração nos campos, essa instancia está executando essa ação
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Email = usuarioSemSenhaModel.Email,
                        Login = usuarioSemSenhaModel.Login,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o usuário. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
