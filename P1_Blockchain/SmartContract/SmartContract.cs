using P1_Blockchain.Client;
using System;
using System.Collections.Generic;

namespace P1_Blockchain.SmartContract
{
    public class SmartContract(IConnectionService conService) : ISmartContract
    {
        private List<Client.IClient> registredClients = [];
        private List<Miner.IMiner> refisteredMiners = [];
        private IConnectionService _conService = conService;

        public async void ListenForClients(){
            while(true)
            {
                Console.WriteLine("Listening for clients...");
                var client = await _conService.GetClient();
                this.ReciveClientData(client);
                Console.WriteLine($"Captured client {0}", client);
            }
        }

        public void ReciveClientData(Client.IClient client)
        {
            registredClients.Add(client);
        }
        public List<Client.IClient> GetregistredClinets()
        {
            return registredClients;
        }
    }
}