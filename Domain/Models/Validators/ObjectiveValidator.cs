using Domain.Models.Dtos.Requests;
using FluentValidation;

namespace Domain.Models.Validators
{
    public sealed class ObjectiveValidator : AbstractValidator<ObjectiveRequest>
    {
        public ObjectiveValidator()
        {
            RuleFor(b => b.Description).NotEmpty();
            RuleFor(b => b.Priority).IsInEnum().NotEmpty();
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.ProjectId).NotEmpty();
        }
    }
}
