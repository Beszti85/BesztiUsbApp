using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace SerialPortTool
{
    internal static class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set a fixed startup timestamp for the log filename
            GlobalDiagnosticsContext.Set("startupTime", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Catch unhandled UI thread exceptions
            Application.ThreadException += (sender, e) =>
            {
                _logger.Fatal(e.Exception, "Unhandled UI thread exception");
                MessageBox.Show("An unexpected error occurred. Check the log for details.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Catch unhandled non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                _logger.Fatal(e.ExceptionObject as Exception, "Unhandled AppDomain exception");
            };
            try
            {
                AppLogger.Info("Application starting");
                Application.Run(new PcSerialTool());
                AppLogger.Info("Application exiting normally");
            }
            finally
            {
                LogManager.Shutdown(); // Ensure to flush and stop internal timers/threads before application exit
            }
        }
    }
}
