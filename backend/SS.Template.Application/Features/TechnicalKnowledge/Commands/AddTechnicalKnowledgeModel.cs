using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.TechnicalKnowledge.Commands
{
    public class AddTechnicalKnowledgeModel : IStatus<EnabledStatus>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
