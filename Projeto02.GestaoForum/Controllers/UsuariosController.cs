using Microsoft.AspNetCore.Mvc;
using Projeto02.GestaoForum.DAL;
using Projeto02.GestaoForum.Models;

namespace Projeto02.GestaoForum.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuariosDao usuariosDao { get; set; }

        public UsuariosController(ForumContext context)
        {
            this.usuariosDao = new UsuariosDao(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            usuariosDao.Executar(usuario, TipoOperacao.Added);
            return RedirectToAction("Listar");
        }

        public IActionResult Listar()
        {
            return View(usuariosDao.Listar());
        }
    }
}
