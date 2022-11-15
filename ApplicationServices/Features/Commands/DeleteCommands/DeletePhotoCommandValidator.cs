using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeletePhotoCommandValidator : AbstractValidator<DeletePhotoCommand>
    {
        public DeletePhotoCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
