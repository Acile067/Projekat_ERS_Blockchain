namespace CommonInterfaces
{
    public interface IMiner : IUser
    {
        public Block CreateBlock(int idb, string data, int previousBlockId);
    }
}
