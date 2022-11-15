using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$").WithMessage("{PropertyName} debe ser una direccion de e-mail válida.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Mobile)
                .Matches(@"^[0-9]+").WithMessage("Teléfono solo debe contener números.")
                .MaximumLength(14).WithMessage("Teléfono no debe exeder de {MaxLength} caracteres.")
                .MinimumLength(6).WithMessage("Teléfono no debe contener menos de {MaxLength} caracteres.");
            RuleFor(x => x.UserRol)
                .NotEmpty().WithMessage("Rol Usuario no puede ser vacío.");
        }
    }
}
