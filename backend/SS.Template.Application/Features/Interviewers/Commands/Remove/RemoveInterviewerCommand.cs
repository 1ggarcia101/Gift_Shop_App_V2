using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Interviewers.Commands.Remove
{
    public class RemoveInterviewerCommand : ICommand
    {
        public Guid id { get; set; }
        public RemoveInterviewerCommand(Guid id)
        {
            this.id = id;
        }

    }
}
