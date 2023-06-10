using System.Diagnostics;

namespace NetShare_Win
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "Binary/NetShare_Core.exe";

            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.RedirectStandardInput = false;
            processStartInfo.RedirectStandardOutput = false;
            processStartInfo.RedirectStandardError = false;

            Process? process = null;

            try
            {
                process = Process.Start(processStartInfo);
                ApplicationConfiguration.Initialize();
                Application.Run(new NetShareForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal error ocurred. NetShare terminated unexpectedly. Error:" + ex.Message, "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (process != null)
                    if (!process.HasExited)
                        process.Kill();
            }

        }
    }
}