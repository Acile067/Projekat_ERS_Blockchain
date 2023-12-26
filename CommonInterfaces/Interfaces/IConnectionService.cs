using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IConnectionService
    {
        public Task<IClient> GetClient();
        public void SendClient(IClient clent);
    }
}