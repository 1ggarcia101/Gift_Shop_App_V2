namespace SS.Template.Domain.Model
{
    public enum EnabledStatus
    {
        Enabled =1,
        Disabled =2,
        Deleted=3
    }

    public static class EnabledStatusExtensions
    {
        public static bool ToBoolean(this EnabledStatus status)
        {
            return status == EnabledStatus.Enabled;
        }

        public static EnabledStatus ToEnabledStatus(this bool enabled)
        {
            return enabled ? EnabledStatus.Enabled : EnabledStatus.Disabled;
        }
    }
}
