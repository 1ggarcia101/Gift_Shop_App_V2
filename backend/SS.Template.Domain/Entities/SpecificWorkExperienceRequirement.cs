using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Domain.Entities
{
    public class SpecificWorkExperienceRequirement : Entity, IStatus<EnabledStatus>
    {
        public string Description { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
