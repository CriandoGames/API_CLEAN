using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x).NotEmpty()
                   .WithMessage("A entidade não pode ser vazia").
                   NotNull().WithMessage("A entidade não poser ser nula");    

            RuleFor(x => x.Name).NotEmpty()
                    .WithMessage("O nome não pode ser vazio").
                    NotNull().WithMessage("O nome não poser ser nula").
                    MinimumLength(3).WithMessage("O nome deve ter no Mínimo 3 caracteres").
                    MaximumLength(80).WithMessage("Onome deve ter no maximo 80 caracteres");


            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Informe o e-mail do cliente")
                    .EmailAddress().WithMessage("E-mail inválido");


            RuleFor(x => x.Password).NotEmpty()
                  .WithMessage("A senha não pode ser vazio").
                  NotNull().WithMessage("A senha não poser ser nula").
                  MinimumLength(6).WithMessage("A senha deve ter no Mínimo 6 caracteres").
                  MaximumLength(80).WithMessage("A senha deve ter no maximo 80 caracteres");


        }
    }
}
