using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SS.Template.Core;

namespace SS.Template.Application.Features.Interviews.Commands
{
    public sealed class AddInterviewsModelValidator : AbstractValidator<AddInterviewsModel>
    {
        public AddInterviewsModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength);
            RuleFor(x => x.CV)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength);
            RuleFor(x => x.InterviewTeam)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength);



        }
    }
}
