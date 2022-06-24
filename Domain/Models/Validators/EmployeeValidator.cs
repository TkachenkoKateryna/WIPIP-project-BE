using Domain.Models.Dtos.Requests;
using FluentValidation;

namespace Domain.Models.Validators
{
    public sealed class EmployeeValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.EnglishLevel).IsInEnum().NotEmpty();
            RuleFor(b => b.DOB).NotEmpty()
                .LessThan(p => DateTime.Now).Must(BeAValidAge).WithMessage("Eployee should be in age range morethan 18 and less than 100");
        }

        private bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear < (currentYear - 18) && dobYear > (currentYear - 100))
            {
                return true;
            }

            return false;
        }
    }
}
