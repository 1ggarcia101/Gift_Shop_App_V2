//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentValidation;

//namespace SS.Template.Application.Features.Interviews.Commands.Add
//{
//    public sealed class AddInterviewsCommandValidator : AbstractValidator<AddInterviewsCommand>
//    {
//        public AddInterviewsCommandValidator()
//        {
//            RuleFor(x => x.Interview).NotEmpty();

//            var innerValidator = new AddInterviewsModelValidator();
//            RuleForEach(x => x.Interview)
//                .SetValidator(innerValidator);
//        }
//    }
//}
