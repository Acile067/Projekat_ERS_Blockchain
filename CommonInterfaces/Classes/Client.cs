using System;

namespace CommonInterfaces
{
    public class Client(int clientId, string data) : IClient
    {
        public int ClientId { get; } = clientId;
        public string Data { get; set; } = data;
        public DateTime CreationTime { get; } = DateTime.Now;

        public void SendDataToSmartContract(ISmartContract smartContract)
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
