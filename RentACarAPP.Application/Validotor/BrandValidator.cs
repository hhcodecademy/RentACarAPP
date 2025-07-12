using FluentValidation;

using RentACarAPP.Contract.Dtos;

namespace RentACarAPP.Application.Validotor
{
    public class BrandValidator : AbstractValidator<BrandDTO>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Brand name is required.")
                .Length(2, 50).WithMessage("Brand name must be between 2 and 50 characters.");
            RuleFor(b => b.Description)
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
        }
    }

}
