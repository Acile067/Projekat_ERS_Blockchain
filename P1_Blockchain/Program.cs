
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain
{
    public class Program
    {
        static void Main(string[] args)
        {
            SmartContract smartContract = new SmartContract();

            Client.Client client1 = new Client.Client(1,"Aleksandar");
            Client.Client client2 = new Client.Client(2, "Mihailo");

            client1.SendDataToSmartContract(smartContract);
            client2.SendDataToSmartContract(smartContract);

            foreach (Client.Client cli in smartContract.GetregistredClinets())
            {
                Console.WriteLine(cli);
            }
        }
    }
}
