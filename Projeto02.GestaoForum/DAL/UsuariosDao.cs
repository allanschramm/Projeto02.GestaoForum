using Projeto02.GestaoForum.Models;

namespace Projeto02.GestaoForum.DAL
{
    public class UsuariosDao : GenericDao<Usuario>
    {
        public UsuariosDao(ForumContext context) : base(context)
        { }
    }
}
