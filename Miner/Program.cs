using CommonInterfaces;
using MinerNamespace;
using System;

internal class Program
{
    private async static Task Main(string[] args)
    {
        var miner = new Miner(); 
        await miner.Register();
        Console.WriteLine("Miner registered successfuly!");
        Console.WriteLine(miner);

        var uiHandler = new MinerUiHandler(miner);
        uiHandler.HandleUI();
    }
}