using Projeto03.AcessoDados.Data;
using Projeto03.AcessoDados.Models;

namespace Projeto03.AcessoDados.DAL
{
    public class ForumDao : GenericDao<Forum>
    {
        public ForumDao(ForumContext context) : base(context)
        {  }
    }
}
