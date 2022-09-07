using anticheat;

Console.WriteLine("Press Enter to test.");
Console.ReadLine();
AnticheatProvider.GetAnticheatProvider().ExecuteModules();
Console.ReadLine();

void HandleBans()
{
    Console.WriteLine("WOOOOORKING!");
}

BanHandler.GetBanHandler().SubscribeBanHandler(HandleBans);

BanHandler.GetBanHandler().Publish();