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
            while(true)
            {   
                var minerList = await _receiver.Receive();
                Console.WriteLine($"Received {minerList.Count} miners");
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }
    }
}
