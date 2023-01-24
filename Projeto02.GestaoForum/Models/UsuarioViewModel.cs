using System.ComponentModel.DataAnnotations;

namespace Projeto02.GestaoForum.Models
{
    public class UsuarioViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }

        public string? Perfil { get; set; }
    }
}
