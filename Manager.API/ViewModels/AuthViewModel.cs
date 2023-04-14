using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class AuthViewModel
    {
        [MinLength(10, ErrorMessage = "O Login deve ter no minimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O Login deve ter no maximo 180 caracteres")]
        [Required(ErrorMessage = "O Login não pode ser vazio")]
        [EmailAddress(ErrorMessage = "O Email não é valido")]
        public required string Login { get; set; }

        [MinLength(6, ErrorMessage = "O Password deve ter no minimo 6 caracteres")]
        [MaxLength(180, ErrorMessage = "O Password deve ter no maximo 180 caracteres")]
        [Required(ErrorMessage = "O Password não pode ser vazio")]
        public required string Password { get; set; }
    }
}
