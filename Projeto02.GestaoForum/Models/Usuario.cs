using System.ComponentModel.DataAnnotations;

namespace Projeto02.GestaoForum.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
