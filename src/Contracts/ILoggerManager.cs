using System.Runtime.CompilerServices;

namespace Contracts;

public interface ILoggerManager
{
    void LogInfo(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "");
    void LogWarning(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "");
    void LogError(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "");
    void LogDebug(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string callerFile = "");
}
