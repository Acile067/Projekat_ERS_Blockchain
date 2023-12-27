namespace CommonInterfaces
{
    public interface IClient : IUser
    {
        void SendData(DataMessage msg);
    }
}
