using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.NameClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.NameLastClient)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$").WithMessage("{PropertyName} debe ser una direccion de e-mail válida.")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotEmpty()
                .MaximumLength(200).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

        }
    }
}
