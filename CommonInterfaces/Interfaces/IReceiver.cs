namespace CommonInterfaces 
{
    public interface IListReceiver 
    {
        Task<List<Miner>> Receive();
    }
}