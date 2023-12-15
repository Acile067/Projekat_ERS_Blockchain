using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain.Client.impl
{
    public class Clinetimpl : IClient
    {
        public int ClientId { get; }
        public string Data { get; }
        public DateTime CreationTime { get; }
        public Clinetimpl(int clientId, string data)
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
