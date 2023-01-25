using Projeto03.AcessoDados.Data;
using Projeto03.AcessoDados.Models;

namespace Projeto03.AcessoDados.DAL
{
    public class UsuariosDao : GenericDao<Usuario>
    {
        public UsuariosDao(ForumContext context) : base(context)
        { }
    }
}
