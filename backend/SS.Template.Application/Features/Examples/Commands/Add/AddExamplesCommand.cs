using System.Collections.Generic;
using SS.Template.Application.Commands;
using SS.Template.Application.Features.Examples.Commands;

namespace SS.Template.Application.Features.Examples.Commands.Add
{
    public class AddExamplesCommand : ICommand
    {
        public List<AddExampleModel> Examples { get; }

        public AddExamplesCommand(List<AddExampleModel> examples)
        {
            Examples = examples;
        }
    }
}
