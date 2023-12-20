using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain.Client
{
    public class Clineti : IClient
    {
        public int ClientId { get; }
        public string Data { get; }
        public DateTime CreationTime { get; }
        public Clineti(int clientId, string data)
        {
            ClientId = clientId;
            Data = data;
            CreationTime = DateTime.Now;
        }
        public void SendDataToSmartContract(SmartContract smartContract)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
