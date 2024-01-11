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
                var cts = new CancellationTokenSource();
                var token = cts.Token;
                var minerListTask = _receiver.Receive(token);
                List<Miner>? minerList;
                await Task.Delay(TimeSpan.FromSeconds(1));
                if(minerListTask.IsCompleted)
                {
                    minerList = minerListTask.Result;
                }
                else
                {
                    cts.Cancel();
                }
            }
        }
    }
}
