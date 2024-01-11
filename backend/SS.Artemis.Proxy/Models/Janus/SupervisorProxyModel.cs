using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Domain.Model;

namespace SS.Artemis.Proxy.Models.Janus
{
    public class SupervisorProxyModel
    {
        public string SupervisorName { get; set; } = string.Empty;
        public Guid? SupervisorEmployeeId { get; set; }
        public int? SupervisorBambooId { get; set; }
        public EnabledStatus SyncStatus { get; set; }
        public Guid Id { get; set; }
        public EnabledStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
