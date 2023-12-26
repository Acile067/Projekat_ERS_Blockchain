using System.Threading.Tasks;

namespace SmartContract
{
    public interface IConnectionService
    {
        public Task<IClient> GetClient();
        public void SendClient(IClient clent);
    }
}