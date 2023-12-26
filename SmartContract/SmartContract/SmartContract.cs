using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P1_Blockchain
{
    public class SmartContract(IConnectionService conService) : ISmartContract
    {
        private List<IClient> registredClients = [];
        private List<IMiner> refisteredMiners = [];
        private IConnectionService _conService = conService;

        public async Task ListenForClients(){
            while(true)
            {
                Console.WriteLine("Listening for clients...");
                var client = await _conService.GetClient();
                ReciveClientData(client);
                Console.WriteLine($"Captured client {client}");
            }
        }

        public void ReciveClientData(IClient client)
        {
            registredClients.Add(client);
        }
        public List<IClient> GetregistredClinets()
        {
            return registredClients;
        }
    }
}