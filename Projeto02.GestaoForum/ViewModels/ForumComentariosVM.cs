namespace Projeto02.GestaoForum.ViewModels
{
    public class ForumComentariosVM
    {
        public int IdComentario { get; set; }
        public int ForumId { get; set; }
        public string? DescricaoForum { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataComentario { get; set; }
    }
}
