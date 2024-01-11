using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonInterfaces;

namespace MinerNamespace
{
    internal class MinerUiHandler(IMiner miner) : IUIHandler
    {
        public async Task HandleUI()
        {
            var minerList = await ConnectionService.MinerRecieve();
            minerList.ForEach(Console.WriteLine);
        }
    }
}
