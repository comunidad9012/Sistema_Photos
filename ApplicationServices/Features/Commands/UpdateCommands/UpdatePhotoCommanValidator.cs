using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePhotoCommandValidator : AbstractValidator<UpdatePhotoCommand>
    {
        public UpdatePhotoCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Size)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
          
            RuleFor(x => x.Idclient)
                .NotEmpty().WithMessage("Rol Usuario no puede ser vacío.");
        }
    }
}
