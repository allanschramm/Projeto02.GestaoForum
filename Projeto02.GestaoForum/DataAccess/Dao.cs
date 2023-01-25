using Dapper.Contrib.Extensions;
using Projeto03.AcessoDados.Models;
using System.Data.SqlClient;

namespace Projeto02.GestaoForum.DataAccess
{
    public class Dao
    {
        string conexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_FORUM;Data Source=.";

        public IEnumerable<Forum> ListarForuns()
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.GetAll<Forum>();
            }
        }

        public long IncluirForum(Forum forum)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Insert<Forum>(forum);
            }
        }

        public Forum BuscarForum(int id)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Get<Forum>(id);
            }
        }

        public bool AlterarForum(Forum forum)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Update<Forum>(forum);
            }
        }

        public bool RemoverForum(Forum forum)
        {
            using (var cn = new SqlConnection(conexao))
            {
                return cn.Delete<Forum>(forum);
            }
        }
    }
}
