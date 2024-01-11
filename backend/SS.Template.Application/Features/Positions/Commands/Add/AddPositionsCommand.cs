using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Positions.Commands.Add
{
    public class AddPositionsCommand : ICommand
    {
        public List<AddPositionsModel> Positions { get; set; }

        public AddPositionsCommand(List<AddPositionsModel> positions)
        {
            Positions = positions;
        }
    }
}
