
using System.Threading.Tasks;

namespace P1_Blockchain
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ConnectionService conService = new();
            SmartContract smartContract = new(conService);
            while(true)
            {
                await smartContract.ListenForClients();
            }
        }
    }
}
