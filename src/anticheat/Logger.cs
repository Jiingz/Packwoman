using System.Diagnostics;

namespace packwoman
{
    internal enum _LOGGER_TYPE
    {
        SUCCESS,
        ERROR,
        INFO,
        WARNING
    }

    /// <summary>
    /// Custom Logger class to log events of the application.
    /// </summary>
    internal class Logger
    {
        private static Logger _logger;

        internal static Logger GetLogger()
        {
            if (_logger == null)
                _logger = new Logger();

            return _logger;
        }

        internal void Log(_LOGGER_TYPE logType, string message)
        {
            StackFrame callStack = new StackFrame(1, true);

            switch (logType)
            {
                case _LOGGER_TYPE.SUCCESS:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + "[SUCCESS] " + callStack.GetMethod().Name + "() -> " + message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case _LOGGER_TYPE.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + "[ERROR] " + callStack.GetMethod().Name + "() -> " + message);
                    Console.WriteLine("[File: " + callStack.GetFileName() + " Line: " + callStack.GetFileLineNumber() + "]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case _LOGGER_TYPE.INFO:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + "[INFO] " + callStack.GetMethod().Name + "() -> " + message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case _LOGGER_TYPE.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + "[WARNING] " + callStack.GetMethod().Name + "() -> " + message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
        }
    }
}
