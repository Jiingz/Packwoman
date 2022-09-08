using anticheat;

Console.WriteLine("Press Enter to test.");
Console.ReadLine();
AnticheatProvider.GetAnticheatProvider().ExecuteModules();
Console.ReadLine();

BanHandler.GetBanHandler().Publish();