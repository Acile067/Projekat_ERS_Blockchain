namespace CommonInterfaces
{
    public interface ISender
    {
        Task SendBlock(Block block);
    }
}