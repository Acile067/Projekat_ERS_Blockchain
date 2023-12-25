namespace P1_Blockchain
{
    public interface IClient
    {
        void SendDataToSmartContract(ISmartContract smartContract);
        void SetData(string data);
    }
}
