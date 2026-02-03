namespace BSNTools.Web.Core.Debugging
{
    public class LogService
    {
        public static List<(string Message, LogLevel Level, LogArea Area)> Logs { get; private set; } = new List<(string, LogLevel, LogArea)>();

        public static void Log(string message, LogLevel level = LogLevel.Info, LogArea area = LogArea.Application)
        {
            Logs.Add(($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {message}", level, area));
        }

        public static IEnumerable<string> GetLogs(LogLevel? level = null, LogArea? area = null)
        {
            return Logs
                .Where(log => (!level.HasValue || log.Level == level.Value) &&
                              (!area.HasValue || log.Area == area.Value))
                .Select(log => log.Message);
        }

        public static IEnumerable<string> GetAllLogs()
        {
            return Logs.Select(log => log.Message);
        }

        public static IEnumerable<string> PrintAllLogs()
        {
            foreach (var log in Logs)
            {
                yield return $"[{log.Level}] [{log.Area}] {log.Message}";
            }
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    public enum LogArea
    {
        Framework,
        Runtime,
        Page,
        Component,
        Service,
        JSInterop,
        Application,
        Internal,
        Other
    }
}
