using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommonInterfaces;

namespace MinerNamespace
{
    internal class MinerUiHandler(IReceiver receiver, ISender sender, IMiner miner) : IUIHandler
    {
        public IReceiver _receiver = receiver;
        public ISender _sender = sender;
        public IMiner _miner = miner;
        public async Task HandleUI()
        {
            while(true)
            {   
                var msg = await _receiver.Receive();
                if(msg != null)
                {
                    switch(msg.Type)
                    {
                        case MsgType.BLOCK:
                            var recvBlock = JsonSerializer.Deserialize<Block>(msg.Data);
                            if(!_miner.GetBlockChain().Exists(x => x.Id == recvBlock!.Id))
                            {
                                _miner.GetBlockChain().Add(recvBlock!);
                                Console.WriteLine($"Received a new block: \n{recvBlock}\n");
                            }
                            break;
                        case MsgType.CLIENT_DATA:
                            Console.WriteLine($"Reveived a message: {msg.Data}");
                            Console.WriteLine("Creating and sending new block...");
                            var block = _miner.CreateBlock(msg);
                            Console.WriteLine($"New block created:\n{block}\n");
                            _miner.GetBlockChain().Add(block);
                            await _sender.SendBlock(block);
                            Console.WriteLine("New block sent!\n");
                            break;
                        case MsgType.MINER_LIST:
                            Console.WriteLine("New miner has registered...");
                            Console.WriteLine($"Miner list: \n{msg.Data}");
                            break;
                        default:
                            break;
                    }
                    
                }
                
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }
}
