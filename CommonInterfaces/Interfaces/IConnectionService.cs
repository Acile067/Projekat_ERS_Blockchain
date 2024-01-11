using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IConnectionService
    {
        public Task<IUser?> ReceieveMessage(int id);
        public Task SendMinerList(string data);
    }
}