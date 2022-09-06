﻿using anticheat.modules;

namespace anticheat
{
    /// <summary>
    /// This class provides the basic anticheat functionality.
    /// </summary>
    public class AnticheatProvider
    {
        // private static instance of the provider.
        static AnticheatProvider _provider;

        // Contains all Anticheat-Modules.
        List<IAnticheatModule> _modules;

        private AnticheatProvider() { }

        /// <summary>
        /// Returns the Singleton of AnticheatProvider.
        /// </summary>
        /// <returns></returns>
        public static AnticheatProvider GetAnticheatProvider()
        {
            if (_provider == null)
                _provider = new AnticheatProvider { _modules = new List<IAnticheatModule>() };

            return _provider;
        }

        /// <summary>
        /// Executes all Anticheat-Modules.
        /// </summary>
        /// <returns><see cref="Task.CompletedTask"/> if the module has been executed successful.</returns>
        public void ExecuteModules()
        {
            Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "Executing Modules");
            foreach (var module in _modules)
            {
                try
                {
                    module.Execute();
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// Adds the given module to the module execution list.
        /// </summary>
        /// <param name="module"></param>
        /// <returns>True if the module has been added.</returns>
        public bool AddModule(IAnticheatModule module)
        {
            int previousCount = _modules.Count;
            _modules.Add(module);

            return _modules.Count > previousCount;
        }
    }

}