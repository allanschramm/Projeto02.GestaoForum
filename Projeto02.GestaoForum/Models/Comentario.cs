using System.ComponentModel;

namespace Projeto02.GestaoForum.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [DisplayName("Fórum")]
        public int ForumId { get; set; }

        [DisplayName("Usuário")]
        public int UsuarioId { get; set; }

        [DisplayName("Comentário")]
        public string? ComentarioInfo { get; set; }
        public DateTime Data { get; set; }
        public Forum? Forum { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
