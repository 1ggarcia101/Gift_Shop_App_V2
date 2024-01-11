using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Interviewers.Commands.Activate
{
    public class ActivateInterviewerCommand : ICommand
    {
        public Guid id { get; set; }
        public ActivateInterviewerCommand(Guid id)
        {
            this.id = id;
        }
    }
}
