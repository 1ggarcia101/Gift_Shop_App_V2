using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Artemis.Proxy.Models.Janus
{
    public class EmployeesProxyModel : IStatus<EnabledStatus>
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string displayName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public Guid? SupervisorId { get; set; }
        public Guid? ManagerId { get; set; }
        public ManagerProxyModel? Manager { get; set; }
        public SupervisorProxyModel? Supervisor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EnabledStatus Status { get; set; }
    }
}
