using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateUserViewModel
    {

        [Required(ErrorMessage = "O Id não pode ser vazio")]
        [MinLength(30, ErrorMessage = "O Id deve ter no minimo 30 caracteres")]
        public Guid Id { get; set; }

        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no maximo 80 caracteres")]
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public required string  Name { get; set; }

        [MinLength(10, ErrorMessage = "O Email deve ter no minimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no maximo 180 caracteres")]
        [Required(ErrorMessage = "O Email não pode ser vazio")]
        [EmailAddress(ErrorMessage = "O Email não é valido")]
        public required string Email { get; set; }

        [MinLength(6, ErrorMessage = "O Password deve ter no minimo 6 caracteres")]
        [MaxLength(180, ErrorMessage = "O Password deve ter no maximo 180 caracteres")]
        [Required(ErrorMessage = "O Password não pode ser vazio")]
        public required string Password { get; set; }
    }
}
