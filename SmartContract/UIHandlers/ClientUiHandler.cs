using System;

namespace SmartContract 
{
    public class ClientUIHandler(IClient client, IConnectionService conService) : IUIHandler
    {
        private readonly IClient _client = client;
        private readonly IConnectionService _conService = conService;
        public void HandleUI()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Data: ");
            string data = Console.ReadLine();
            _client.SetData(data);
            _conService.SendClient(_client);
        }
    }
}