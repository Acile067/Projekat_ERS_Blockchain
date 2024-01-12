using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IConnectionService
    {
        public Task ReceieveMessage(int id, List<IUser> users);
        public void SendMinerList(List<IUser> users);
    }
}