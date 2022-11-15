using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateEventsCommandValidator : AbstractValidator<UpdateEventsCommand>
    {
        public UpdateEventsCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            //RuleFor(x => x.IdType)
            //    .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
            //    .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Service)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
                

        }
    }
}