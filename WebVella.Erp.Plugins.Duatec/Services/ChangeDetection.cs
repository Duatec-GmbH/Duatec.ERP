namespace WebVella.Erp.Plugins.Duatec.Services
{
    public static class ChangeDetection
    {
        private static readonly object _articleLockObject = new();
        private static readonly object _projectLockObject = new();
        private static readonly object _warehouseLocationLockObject = new();
        private static readonly object _warehouseLockObject = new();

        private static DateTime _lastArticleChangeTimeUtc = DateTime.UtcNow;
        private static DateTime _lastProjectChangeTimeUtc = DateTime.UtcNow;
        private static DateTime _lastWarehouseLocationChangeTimeUtc = DateTime.UtcNow;
        private static DateTime _lastWarehouseChangeTimeUtc = DateTime.UtcNow;

        public static DateTime LastArticleChangeTimeUtc 
        {
            get => _lastArticleChangeTimeUtc;
            internal set
            {
                lock (_articleLockObject)
                    _lastArticleChangeTimeUtc = value;
            }
        }

        public static DateTime LastProjectChangeTimeUtc
        {
            get => _lastProjectChangeTimeUtc;
            internal set
            {
                lock (_projectLockObject)
                    _lastProjectChangeTimeUtc = value;
            }
        }

        public static DateTime LastWarehouseLocationChangeTimeUtc
        {
            get => _lastWarehouseLocationChangeTimeUtc;
            internal set
            {
                lock (_warehouseLocationLockObject)
                    _lastWarehouseLocationChangeTimeUtc = value;
            }
        }

        public static DateTime LastWarehouseChangeTimeUtc
        {
            get => _lastWarehouseChangeTimeUtc;
            internal set
            {
                lock (_warehouseLockObject)
                    _lastWarehouseChangeTimeUtc = value;
            }
        }
    }
}
