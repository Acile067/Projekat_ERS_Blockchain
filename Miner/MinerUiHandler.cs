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
            var minerList = await _receiver.Receive();
            minerList.ForEach(Console.WriteLine);
        }
    }
}
