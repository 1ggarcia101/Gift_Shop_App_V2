using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviewers
{
    public class InterviewerModel : IStatus<EnabledStatus>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public DateTime LastUpdate { get; set; }
        public EnabledStatus Status { get; set; }
        public EnabledStatus ActiveInterviewer { get; set; }

    }
}
