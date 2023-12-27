namespace CommonInterfaces
{
    public interface IRegisterable
    {
        public Task<IUser?> Register();
    }
}