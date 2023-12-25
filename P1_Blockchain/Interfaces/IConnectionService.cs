using System.Threading.Tasks;

namespace P1_Blockchain
{
    public interface IConnectionService
    {
        public Task<IClient> GetClient();
        public void SendClient(IClient clent);
    }
}