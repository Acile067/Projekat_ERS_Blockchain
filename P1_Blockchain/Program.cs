
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
            ConnectionService conService = new();
            SmartContract smartContract = new(conService);
            smartContract.ListenForClients();

            while(true)
            {
                Console.WriteLine("Chose your class:\n\t1. Client\n\t2. Miner");
                var clientHandler = new ClientUIHandler(new Client(0,"dada"), conService);
                clientHandler.HandleUI();
            }
        }
    }
}
