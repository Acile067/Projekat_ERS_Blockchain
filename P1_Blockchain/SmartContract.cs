using P1_Blockchain.Client;
using System.Collections.Generic;

namespace P1_Blockchain
{
    public class SmartContract
    {
        private List<Client.Client> registredClinets;

        public SmartContract()
        {
            this.registredClinets = new List<Client.Client>();
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