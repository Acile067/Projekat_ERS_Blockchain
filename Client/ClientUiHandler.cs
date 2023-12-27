using System;
using CommonInterfaces;

namespace ClientNamespace 
{
    public class ClientUIHandler(IClient client, IConnectionService conService) : IUIHandler
    {
        private readonly IClient _client = client;
        private readonly IConnectionService _conService = conService;
        public void HandleUI()
        {
            Console.WriteLine("Sending client data to the Smart Contract...");
            //_conService.SendClient(_client);
            Console.WriteLine("Client data sent to the Smart Contract!");
        }
    }
}