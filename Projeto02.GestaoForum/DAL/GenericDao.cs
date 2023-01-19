using Microsoft.EntityFrameworkCore;
using Projeto02.GestaoForum.Models;

namespace Projeto02.GestaoForum.DAL
{
    public enum TipoOperacao
    {
        Detached = 0,
        Unchanged = 1,
        Deleted = 2,
        Modified = 3,
        Added = 4
    }

    public abstract class GenericDao<T> where T: class
    {
        private ForumContext Context { get; set; }
        public GenericDao(ForumContext context)
        {
            this.Context = context;
        }

        public void Executar(T item, TipoOperacao tipo)
        {
            Context.Entry<T>(item).State = (EntityState)tipo;
            Context.SaveChanges();
        }

        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }
        public T? BuscarPorId(int id)
        {
            return Context.Set<T>().Find();
        }
    }
}
