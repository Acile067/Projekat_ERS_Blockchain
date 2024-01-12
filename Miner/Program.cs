using CommonInterfaces;
using MinerNamespace;
using System;

internal class Program
{
    private async static Task Main(string[] args)
    {
        var miner = new Miner(); 
        var receiver = new MinerReceivingService();
        var sender = new MinerSendingService();
        await miner.Register();
        Console.WriteLine("Miner registered successfuly!");
        Console.WriteLine(miner);

        var uiHandler = new MinerUiHandler(receiver, sender, miner);
        await uiHandler.HandleUI();
    }
}