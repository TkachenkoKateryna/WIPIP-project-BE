using Domain.Models.Dtos.Requests;
using FluentValidation;

namespace Domain.Models.Validators
{
    public sealed class CandidateValidator : AbstractValidator<CandidateRequest>
    {
        public CandidateValidator()
        {
            RuleFor(b => b.FTE).LessThanOrEqualTo(1).NotEmpty();
            RuleFor(b => b.EnglishLevel).IsInEnum().NotEmpty();
            RuleFor(b => b.Proficiency).IsInEnum().NotEmpty();
            RuleFor(b => b.InternalRate).NotEmpty();
            RuleFor(b => b.ExternalRate).NotEmpty();
            RuleFor(b => b.SkillId).NotEmpty();
            RuleFor(b => b.ProjectId).NotEmpty();
        }
    }
}
