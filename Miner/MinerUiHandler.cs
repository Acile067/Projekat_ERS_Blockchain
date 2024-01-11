using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CommonInterfaces;

namespace MinerNamespace
{
    internal class MinerUiHandler(IListReceiver receiver) : IUIHandler
    {
        public IListReceiver _receiver = receiver;
        public async Task HandleUI()
        {
            while (true)
            {
                var delayTask = Task.Delay(5000);
                var receiveTask = _receiver.Receive();

                await Task.WhenAny(delayTask, receiveTask);

                
                if (delayTask.IsCompleted)
                {
                    Console.WriteLine("No new data received within the last second.");
                }
                else
                {
                    var minerList = await receiveTask;
                    Console.WriteLine("Received miner list:");
                    minerList.ForEach(Console.WriteLine);
                }
            }
        }
    }
}
