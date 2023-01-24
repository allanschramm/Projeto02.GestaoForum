using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto02.GestaoForum.DataAccess;
using Projeto02.GestaoForum.Models;

namespace Projeto02.GestaoForum.Controllers
{
    public class ForumController : Controller
    {
        private Dao dao;

        public ForumController()
        {
            if(dao == null)
            {
                dao = new Dao();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarTodos()
        {
            return View(dao.ListarForuns());
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CadastroForum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroForum(Forum forum)
        {
            try
            {
                dao.IncluirForum(forum);
                //return View();
                return RedirectToAction("ListarTodos"); // produz uma requisição GET
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        private IActionResult ProcessarForum(int id, string viewName)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Valor inválido para o código do fórum");
                }
                Forum forum = dao.BuscarForum(id);
                if (forum == null)
                {
                    throw new ArgumentException("Nenhum fórum encontrado com o código informado");
                }

                return View(viewName, forum);

            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }



        [HttpGet]
        public IActionResult AlterarForum(int id)
        {
            return ProcessarForum(id, "AlterarForum");
        }

        [HttpPost]
        public IActionResult AlterarForum(Forum forum)
        {
            try
            {
                dao.AlterarForum(forum);
                return RedirectToAction("ListarTodos");
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }

        [HttpGet]
        public IActionResult RemoverForum(int id)
        {
            return ProcessarForum(id, "RemoverForum");
        }

        [HttpPost]
        public IActionResult RemoverForum(Forum forum)
        {
            try
            {
                dao.RemoverForum(forum);
                return RedirectToAction("ListarTodos");
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }
    }
}
