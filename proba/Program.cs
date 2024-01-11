using SmartContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonInterfaces;


namespace proba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Miner miner = new Miner();
            miner.CreateBlock("dasd", 11);

            Console.ReadLine();
        }


    }
}
