using CommonInterfaces;
using CommonInterfaces.Services;
using MinerNamespace;
using System;

internal class Program
{
    private async static Task Main(string[] args)
    {
        MinerRCV_Service minerRCV_Service = new MinerRCV_Service();
        var miner = new Miner();

        // Start listening for miner connections in the background
        Task.Run(() => minerRCV_Service.ListenForMinerConnections());

        await miner.Register();
        Console.WriteLine("Miner registered successfully!");
        Console.WriteLine(miner);

        // Handle UI in a separate task
        var uiHandler = new MinerUiHandler(miner);
        Task.Run(() => uiHandler.HandleUI());

        // Keep the main thread alive
        while (true)
        {
            // Do any other necessary tasks or simply sleep for a while
            await Task.Delay(1000);
        }
    }
}