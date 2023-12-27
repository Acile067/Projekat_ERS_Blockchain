using ClientNamespace;
using CommonInterfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the data you want to send: ");
        string? data = Console.ReadLine();
        
        var client = new Client(); //TODO: proveriti da li je data null
        var conService = new ClientConnectionService();
        var uiHandler = new ClientUIHandler(client, conService);
        uiHandler.HandleUI();
    }
}