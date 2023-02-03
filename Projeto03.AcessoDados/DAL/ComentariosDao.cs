

using Projeto03.AcessoDados.Data;
using Projeto03.AcessoDados.Models;
using Projeto03.AcessoDados.ViewModels;

namespace Projeto03.AcessoDados.DAL
{
    public class ComentariosDao : GenericDao<Comentario>
    {
        public ForumContext Context { get; set; }
        public ComentariosDao(ForumContext context) : base(context)
        {
            this.Context = context;
        }

        public IEnumerable<ForumComentariosVM> ListarComentariosPorForum(int idForum)
        {
            var lista = Context.Forums.Join(
                    Context.Comentarios,
                    f => f.Id,
                    c => c.ForumId,
                    (f, c) => new ForumComentariosVM
                    {
                        IdComentario = c.Id,
                        ForumId = f.Id,
                        Comentario = c.ComentarioInfo,
                        DescricaoForum = f.Descricao,
                        DataComentario = c.Data
                    }
                ).Where(p => (idForum > 0 ? p.ForumId == idForum : p.ForumId > 0));

            return lista.ToList();
        }
        //public IEnumerable<ForumComentariosVM> ListarComentariosPorForum(int idForum)
        //{
        //    var comentarios = this.ListarComentariosPorForum();
        //    if(idForum > 0)
        //    {
        //        comentarios = comentarios.Where(p => p.ForumId == idForum);
        //    }
        //    return comentarios;
        //}

    }
}
