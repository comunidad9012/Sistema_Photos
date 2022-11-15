using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeleteEventsCommandValidator : AbstractValidator<DeleteEventsCommand>
    {
        public DeleteEventsCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
