namespace CommonInterfaces 
{
    public interface IUser
    {
        public int GetId();
        public Task Register();
    }
}