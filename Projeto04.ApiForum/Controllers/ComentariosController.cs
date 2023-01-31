using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto02.GestaoForum.DAL;
using Projeto02.GestaoForum.Models;
using Projeto02.GestaoForum.ViewModels;

namespace Projeto04.ApiForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentariosDao comentariosDao;

        public ComentariosController(ForumContext context)
        {
            comentariosDao = new ComentariosDao(context);
        }

        [HttpGet]
        public IEnumerable<Comentario> GetComentarios()
        {
            return comentariosDao.Listar();
        }

        [HttpGet("{idForum}")]
        public IEnumerable<ForumComentariosVM> GetForumComentarios(int idForum)
        {
            return comentariosDao.ListarComentariosPorForum(idForum);
        }
    }
}
