using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreateEventsCommandValidator : AbstractValidator<CreateEventsCommand>
    {
        public CreateEventsCommandValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("{PropertyType} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Service);


            RuleFor(x => x.date)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");




        }
    }
}
