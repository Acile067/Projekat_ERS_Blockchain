using P1_Blockchain.Client;
using System.Collections.Generic;

namespace P1_Blockchain.SmartContract
{
    public class SmartContract : ISmartContract
    {
        private List<Client.Client> registredClinets;

        public SmartContract()
        {
            registredClinets = new List<Client.Client>();
        }

        public void ReciveClientData(Client.Client client)
        {
            registredClinets.Add(client);
        }
        public List<Client.Client> GetregistredClinets()
        {
            return registredClinets;
        }
    }
}