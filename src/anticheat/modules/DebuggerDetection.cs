using packwoman;
using packwoman.modules;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace packwoman.modules
{
    public class DebuggerDetection : IAnticheatModule
    {
        string[] debuggers = { "IDA" };

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
            if (IsDebuggerOpen().Item1)
                Logger.GetLogger().Log(_LOGGER_TYPE.WARNING, "A open debugger has been found: " + IsDebuggerOpen().Item2);
        }
    }
}
