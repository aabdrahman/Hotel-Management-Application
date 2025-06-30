using Contracts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService;

public class LoggerManager : ILoggerManager
{
    private readonly ILogger _logger = Log.ForContext<LoggerManager>();

    public void LogDebug(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "")
    {
        string className = Path.GetFileNameWithoutExtension(callerFile);
        _logger.ForContext("ClassName", className)
            .ForContext("MethodName", callerName)
            .Debug(message);
    }

    public void LogError(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "")
    {
        string className = Path.GetFileNameWithoutExtension(callerFile);

        _logger.ForContext("ClassName", className)
            .ForContext("MethodName", callerName)
            .Error(message);
    }

    public void LogInfo(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "")
    {
        string? className = Path.GetFileNameWithoutExtension(callerFile);
        _logger.ForContext("ClassName", className)
            .ForContext("MethodName", callerName)
            .Information(message);
    }

    public void LogWarning(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "")
    {
        string? className = Path.GetFileNameWithoutExtension(callerFile);
        _logger.ForContext("", className)
            .ForContext("", callerName)
            .Warning(message);
    }
}
