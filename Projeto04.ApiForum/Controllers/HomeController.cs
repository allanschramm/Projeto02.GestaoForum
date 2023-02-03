using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto04.ApiForum.Classes;

namespace Projeto04.ApiForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index() // HTTP GET
        {
            return "Asp.Net Core Web API";
        }

        [HttpGet("{id}")]
        public string Index(int id)
        {
            return $"Carga Horária: {id}";
        }

        [HttpGet("empresa")]
        public string MostrarEmpresa()
        {
            return "Impacta e Atos : ";
        }

        [HttpGet]
        [Route("lista")]
        public IEnumerable<Curso> GetCursos()
        {
            return Listas.ListarCursos();
        }

        [HttpGet]
        [Route("lista/{id}")]
        public Curso? GetCurso(int id)
        {
            return Listas.ListarCursos().FirstOrDefault(p => p.Id == id);
        }
    }
}
