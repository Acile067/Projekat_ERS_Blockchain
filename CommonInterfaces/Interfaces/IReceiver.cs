namespace CommonInterfaces 
{
    public interface IReceiver 
    {
        Task<DataMessage?> Receive();
    }
}