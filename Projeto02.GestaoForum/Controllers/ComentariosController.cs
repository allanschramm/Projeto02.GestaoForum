using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto03.AcessoDados.DAL;
using Projeto03.AcessoDados.Data;
using Projeto03.AcessoDados.Models;

namespace Projeto02.GestaoForum.Controllers
{
    public class ComentariosController : Controller
    {
        private ForumDao forumDao { get; set; }
        private UsuariosDao usuariosDao { get; set; }
        private ComentariosDao comentariosDao { get; set; }

        public ComentariosController(ForumContext context)
        {
            this.forumDao = new ForumDao(context);
            this.usuariosDao = new UsuariosDao(context);
            this.comentariosDao = new ComentariosDao(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            ViewBag.Foruns = new SelectList(forumDao.Listar(), "Id", "Descricao");
            ViewBag.Usuarios = new SelectList(usuariosDao.Listar(), "Id", "Nome");


            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Comentario comentario)
        {
            try
            {
                comentario.Data = DateTime.Now;
                comentariosDao.Executar(comentario, TipoOperacao.Added);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        [HttpGet]
        public IActionResult ListarPorForum(int idForum)
        {
            try
            {
                ViewBag.Foruns = new SelectList(forumDao.Listar(), "Id", "Descricao");
                return View(comentariosDao.ListarComentariosPorForum(idForum));
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        public IActionResult ListarPorForumAjax(int idForum)
        {
            ViewBag.Foruns = new SelectList(forumDao.Listar(), "Id", "Descricao");
            if(idForum == 0)
            {
                return View();
            }
            else
            {
                var lista = comentariosDao.ListarComentariosPorForum(idForum);
                return PartialView("_ListaComentarios", lista);
            }
        }
    }
}
