
using System.Threading.Tasks;
using CommonInterfaces;

namespace SmartContract
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
