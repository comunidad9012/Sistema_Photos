using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePhotographerCommandValidator : AbstractValidator<UpdatePhotographerCommand>
    {
        public UpdatePhotographerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.QualityPhoto)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.SizePhoto)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotEmpty()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
          
            RuleFor(x => x.UserRol)
                .NotEmpty().WithMessage("Rol Usuario no puede ser vacío.");
        }
    }
}
