using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.JobDescription
{
    public class JobDescriptionModel : IStatus<EnabledStatus>
    {

        public Guid Id { get; set; }
        public string Description { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
