using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Interviews.Commands.Add
{
    public class AddInterviewsCommand : ICommand
    {
        public AddInterviewsModel Interview { get; set; }

        public AddInterviewsCommand(AddInterviewsModel interview)
        {
            Interview = interview;
        }
    }
}
