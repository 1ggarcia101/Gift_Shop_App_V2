using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Positions.Commands.Remove
{
    public class RemovePositionsCommand : ICommand
    {
        public Guid Id { get; set; }

        public RemovePositionsCommand(Guid id)
        {
            Id = id;
        }
    }
}
