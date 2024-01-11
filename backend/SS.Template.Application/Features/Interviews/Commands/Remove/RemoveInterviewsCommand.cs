using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Interviews.Commands.Remove
{
    public class RemoveInterviewsCommand : ICommand
    {
        public Guid Id { get; set; }

        public RemoveInterviewsCommand(Guid id)
        {
            Id = id;
        }
    }
}
