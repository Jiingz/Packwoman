using packwoman;
using packwoman.modules;

void HandleBans()
{
    //Ban Logic
    Console.WriteLine("You have been banned!");
}

BanHandler.GetBanHandler().SubscribeBanHandler(HandleBans);

Console.WriteLine("Press Enter to test.");
Console.ReadLine();

AnticheatProvider.GetAnticheatProvider().ExecuteModules();

Console.ReadLine();
