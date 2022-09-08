using packwoman;
using packwoman.modules;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace packwoman.modules
{
    public class DebuggerDetection : IAnticheatModule
    {
        string[] debuggers = { "IDA" };

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        private (bool, string) IsDebuggerOpen()
        {
            Process[] processlist = Process.GetProcesses();

            for (int i = 0; i < processlist.Length; i++)
            {
                var proc = processlist[i];
                for (int y = 0; y < debuggers.Length; y++)
                {
                    if (proc.MainWindowTitle.ToLower().Contains(debuggers[y].ToLower()))
                        return (true, proc.MainWindowTitle);
                }

            }

            return (false, string.Empty);
        }

        public void Execute()
        {
            bool isDebuggerPresent = false;
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);

            if (isDebuggerPresent)
                Logger.GetLogger().Log(_LOGGER_TYPE.WARNING, "A attached Debugger has been found!");

            if (IsDebuggerOpen().Item1)
                Logger.GetLogger().Log(_LOGGER_TYPE.WARNING, "A open debugger has been found: " + IsDebuggerOpen().Item2);
        }
    }
}
