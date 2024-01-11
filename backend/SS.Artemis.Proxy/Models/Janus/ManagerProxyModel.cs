
using SS.Template.Domain.Model;

namespace SS.Artemis.Proxy.Models.Janus
{
    public class ManagerProxyModel
    {
        public int ManagerBambooId { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        public Guid ManagerEmployeeId { get; set; }
        public EnabledStatus SyncStatus { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EnabledStatus Status { get; set; }
    }
}
