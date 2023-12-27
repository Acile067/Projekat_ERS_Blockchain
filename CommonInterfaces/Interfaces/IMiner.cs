namespace CommonInterfaces
{
    public interface IMiner : IUser
    {
        void Register(ISmartContract smartContract);
    }
}
