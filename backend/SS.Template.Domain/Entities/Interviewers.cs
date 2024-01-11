using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Template.Domain.Entities
{
    public class Interviewers : Entity,IStatus<EnabledStatus>, IHaveDateCreated, IHaveDateUpdated
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Location { get; set; }
        public string BambooStatus { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public EnabledStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public EnabledStatus ActiveInterviewer { get; set; } = EnabledStatus.Enabled;


    }
}
