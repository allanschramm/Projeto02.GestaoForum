using Projeto02.GestaoForum.Models;

namespace Projeto02.GestaoForum.DAL
{
    public class ForumDao : GenericDao<Forum>
    {
        public ForumDao(ForumContext context) : base(context)
        {  }
    }
}
