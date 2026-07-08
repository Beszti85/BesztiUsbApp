using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Logger.cs
using NLog;

public static class AppLogger
{
    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public static void Debug(string message) => _logger.Debug(message);
    public static void Info(string message) => _logger.Info(message);
    public static void Warn(string message) => _logger.Warn(message);
    public static void Error(string message, Exception ex = null)
    {
        if (ex != null) _logger.Error(ex, message);
        else _logger.Error(message);
    }
    public static void Fatal(string message, Exception ex = null)
    {
        if (ex != null) _logger.Fatal(ex, message);
        else _logger.Fatal(message);
    }
}