using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.TechSkills
{
    public class TechSkillsModel : IStatus<EnabledStatus>
    {
        public Guid Id { get; set; }

        public string Skill { get; set; }

        public int Level { get; set; }

        public EnabledStatus Status { get; set; }

    }
}
