using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Operations.Commands.BugCreate
{
    public class BugCreateValidator : AbstractValidator<BugCreateCommand>
    {
        public BugCreateValidator()
        {
            RuleFor(x => x.Title).MaximumLength(50).NotEmpty();

            RuleFor(x => x.Description).MaximumLength(500).NotEmpty();

            RuleFor(x => x.Reproduce).MaximumLength(500).NotEmpty();

            RuleFor(x => x.Environment).MaximumLength(50).NotEmpty();

            RuleFor(x => x.SuggestionForFix).MaximumLength(500);

            RuleFor(x => x.StatusId).GreaterThan(0).NotEmpty();

            RuleFor(x => x.PriorityId).GreaterThan(0).NotEmpty();

            RuleFor(x => x.ProjectVersionId).NotEmpty();
        }
    }
}