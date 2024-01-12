using System;
using CommonInterfaces;

namespace ClientNamespace 
{
    public class ClientUIHandler(IClient client) : IUIHandler
    {
        private readonly IClient _client = client;
        public Task HandleUI()
        {
            while(true)
            {
                Console.WriteLine("Enter data:");
                string data = Console.ReadLine();
                ConnectionService.SendMessage(new DataMessage { UserId = _client.GetId(), Data = data, DateTime = DateTime.Now, Type = MsgType.CLIENT_DATA});
                Console.WriteLine("Data sent to the Smart Contract!\n");
            }
        }
    }
}
