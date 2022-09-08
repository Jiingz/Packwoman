using anticheat.exceptions;
using System.Diagnostics;

namespace anticheat.modules
{
    internal class BlacklistedDLLModule : IAnticheatModule
    {
        //Array which contains all blacklisted modules.
        string[] _blacklistedModules = { "Payload.dll" };

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
                else
                    BanHandler.GetBanHandler().Publish();
            }

            return false;
        }

        public void Execute()
        {
            Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "Checking for blacklisted modules...");

            if (DetectBlacklistedModules())

                Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "Blacklisted module found!");
            else
                Logger.GetLogger().Log(_LOGGER_TYPE.INFO, "No blacklisted module found.");

        }
    }
}
