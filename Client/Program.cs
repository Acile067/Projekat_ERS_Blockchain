using ClientNamespace;
using CommonInterfaces;

internal class Program
{
    private async static Task Main(string[] args)
    {
        var client = new Client(); //TODO: proveriti da li je data null
        var regService = new ClientRegisterService();
        await client.Register(regService);
        Console.WriteLine("Client registered successfuly!");
        Console.WriteLine(client);
        
        var uiHandler = new ClientUIHandler(client);
        await uiHandler.HandleUI();
    }
}
