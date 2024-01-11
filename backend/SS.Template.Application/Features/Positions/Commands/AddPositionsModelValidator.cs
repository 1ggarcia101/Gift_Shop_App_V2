using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SS.Template.Core;

namespace SS.Template.Application.Features.Positions.Commands
{
    public sealed class AddPositionsModelValidator : AbstractValidator<AddPositionsModel>
    {
        public AddPositionsModelValidator()
        {
            RuleFor(x => x.PositionName)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength);
            RuleFor(x => x.Area)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength);
            RuleFor(x => x.Location)
                .NotEmpty()
                .MaximumLength(AppConstants.StandardValueLength); 



        }
    }
}
