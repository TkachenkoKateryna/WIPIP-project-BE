using Domain.Models.Dtos.Requests;
using FluentValidation;

namespace Domain.Models.Validators
{
    public sealed class CandidateValidator : AbstractValidator<CandidateRequest>
    {
        public CandidateValidator()
        {
            RuleFor(b => b.FTE).NotEmpty()
                .Must(BeAValidFTE).WithMessage("FTE should be equal to one of following options: 0.25, 0.5, 0.75, 1"); ;
            RuleFor(b => b.EnglishLevel).IsInEnum().NotEmpty();
            RuleFor(b => b.Proficiency).IsInEnum().NotEmpty();
            RuleFor(b => b.InternalRate).NotEmpty();
            RuleFor(b => b.ExternalRate).NotEmpty();
            RuleFor(b => b.SkillId).NotEmpty();
            RuleFor(b => b.ProjectId).NotEmpty();
        }

        private bool BeAValidFTE(double fte)
        {
            if (fte == 0.25 || fte == 0.5 || fte == 0.75 || fte == 1)
            {
                return true;
            }

            return false;
        }
    }
}
