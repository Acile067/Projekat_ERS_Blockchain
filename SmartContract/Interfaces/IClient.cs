namespace SmartContract
{
    public interface IClient
    {
        void SendDataToSmartContract(ISmartContract smartContract);
        void SetData(string data);
    }
}
