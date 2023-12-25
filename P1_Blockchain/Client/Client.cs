using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain.Client
{
    public class Client : IClient
    {
        public int ClientId { get; }
        public string Data { get; set; }
        public DateTime CreationTime { get; }
        public Client(int clientId, string data)
        {
            ClientId = clientId;
            Data = data;
            CreationTime = DateTime.Now;
        }
        public void SendDataToSmartContract(SmartContract.SmartContract smartContract)
        {
            smartContract.ReciveClientData(this);
        }

        public override string ToString()
        {
            return string.Format("{0,3} {1,-15} {2,15}", ClientId, Data, CreationTime);
        }

        public void SetData(string data)
        {
            this.Data = data;
        }
    }
}
