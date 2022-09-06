namespace anticheat
{
    internal enum _LOGGER_TYPE
    {
        SUCCESS,
        ERROR,
        INFO
    }

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
            switch (logType)
            {
                case _LOGGER_TYPE.SUCCESS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case _LOGGER_TYPE.ERROR:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case _LOGGER_TYPE.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
