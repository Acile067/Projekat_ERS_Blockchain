using System.Threading.Tasks;
using P1_Blockchain.Client;

namespace P1_Blockchain
{
    public interface IConnectionService
    {
        public Task<Client.IClient> GetClient();
        public void SendClient(IClient clent);
    }
}