using ClientNamespace;
using CommonInterfaces;

internal class Program
{
    private async static Task Main(string[] args)
    {
        //Console.Write("Enter the data you want to send: ");
        //string? data = Console.ReadLine();
        
        var client = new Client(); //TODO: proveriti da li je data null
        await client.Register();
        var conService = new ClientConnectionService();
        Console.WriteLine(client);
        //var uiHandler = new ClientUIHandler(client, conService);
        //uiHandler.HandleUI();
    }
}