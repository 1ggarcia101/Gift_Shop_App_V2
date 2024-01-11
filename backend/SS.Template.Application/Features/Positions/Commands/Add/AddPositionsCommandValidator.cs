using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SS.Template.Application.Features.Positions.Commands.Add
{
    public sealed class AddPositionsCommandValidator : AbstractValidator<AddPositionsCommand>
    {
        public AddPositionsCommandValidator()
        {
            RuleFor(x => x.Positions).NotEmpty();

            var innerValidator = new AddPositionsModelValidator();
            RuleForEach(x => x.Positions)
                .SetValidator(innerValidator);
        }
    }
}
