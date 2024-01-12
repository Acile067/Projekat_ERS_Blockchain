namespace CommonInterfaces
{
    public interface IMiner : IUser
    {
        public Block CreateBlock(DataMessage data);
        public List<Block> GetBlockChain();
    }
}
