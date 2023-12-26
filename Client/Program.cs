using ClientNamespace;
using CommonInterfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        string? data;
        if(args.Length >= 2)
        {
            data = args[1];
        } 
        else 
        {
            Console.Write("Enter the data you want to send: ");
            data = Console.ReadLine();
        }
        var client = new Client(0, data!); //TODO: proveriti da li je data null
        var conService = new ConnectionService();
        var uiHandler = new ClientUIHandler(client, conService);
        uiHandler.HandleUI();
    }
}