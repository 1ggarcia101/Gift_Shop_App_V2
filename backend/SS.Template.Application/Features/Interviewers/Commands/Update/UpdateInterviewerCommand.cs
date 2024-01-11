using System;
using SS.Template.Application.Commands;

namespace SS.Template.Application.Features.Interviewers.Commands.Update
{
    public class UpdateInterviewerCommand:ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }

    }
}
