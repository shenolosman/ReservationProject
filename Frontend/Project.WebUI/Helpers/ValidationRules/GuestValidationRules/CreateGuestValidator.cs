using FluentValidation;
using Project.WebUI.Dtos.GuestDto;

namespace Project.WebUI.Helpers.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(100).WithMessage("Maximum length is reached out!");
            RuleFor(x => x.City).NotEmpty().MinimumLength(2).WithMessage("Minimum length 2 char should be written!");
        }
    }
}
