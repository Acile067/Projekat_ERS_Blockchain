﻿using ClientNamespace;
using CommonInterfaces;

internal class Program
{
    private async static Task Main(string[] args)
    {
        var client = new Client(); //TODO: proveriti da li je data null
        await client.Register();
        Console.WriteLine("Client registered successfuly!");
        Console.WriteLine(client);
        
        var uiHandler = new ClientUIHandler(client);
        uiHandler.HandleUI();
    }
}
