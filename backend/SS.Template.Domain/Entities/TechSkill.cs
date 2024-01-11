using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Domain.Entities
{
    public class TechSkill : Entity, IStatus<EnabledStatus>
    {
        public string Skill { get; set; }

        public int Level { get; set; }

        public EnabledStatus Status { get; set; }

    }
}
