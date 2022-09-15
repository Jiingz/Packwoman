using anticheat.exceptions;
using System.Diagnostics;

namespace anticheat.modules
{
    internal class BlacklistedDLLModule : IAnticheatModule
    {
        //Array which contains all blacklisted modules.
        List<string> _blacklistedModules = new List<string> { "Payload.dll" };

        /// <summary>
        /// Returns true if then given module name has been found.
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <returns>True if the module has been found.</returns>
        /// <exception cref="PrivilegeException">Thrown if the user doesn't have required privilges to run this method.</exception>
        private bool IsModuleLoaded(String ModuleName)
        {
            bool loaded = false;
            Process processes = Process.GetCurrentProcess();

            if (processes == null)
            {
                Logger.GetLogger().Log(_LOGGER_TYPE.ERROR, "Failed to retrieve the process handle.");
                throw new PrivilegeException("Failed to get the current process.");
            }


            ProcessModule myProcessModule = null;
            ProcessModuleCollection myProcessModuleCollection;

            try
            {
                myProcessModuleCollection = processes.Modules;

                for (int j = 0; j < myProcessModuleCollection.Count; j++)
                {
                    myProcessModule = myProcessModuleCollection[j];
                    //Console.WriteLine(myProcessModule.ModuleName);
                    if (myProcessModule.ModuleName.Contains(ModuleName))
                    {
                        Logger.GetLogger().Log(_LOGGER_TYPE.SUCCESS, "Blacklisted module found! Module Name: " + myProcessModule.ModuleName);

                        loaded = true;
                        break;
                    }
                }
            }
            catch { loaded = false; }

            return loaded;
        }

        //Checks for loaded blacklisted modules.
        private bool DetectBlacklistedModules()
        {
            foreach (var moduleName in _blacklistedModules)
            {
                if (IsModuleLoaded(moduleName))
                    return true;

            }

            return false;
        }

        public void AddBlacklistedModule(string moduleName)
        {
            _blacklistedModules.Add(moduleName);
        }

        public void Execute()
        {
            Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "Checking for blacklisted modules...");

            if (DetectBlacklistedModules())
            {
                Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "Blacklisted module found!");
                BanHandler.GetBanHandler().Publish();
            }
            else
                Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "No blacklisted module found.");

        }
    }
}
