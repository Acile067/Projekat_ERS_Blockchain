using System;

namespace P1_Blockchain 
{
    public class Miner
    {
        public int Id { get; set; }
        public double BTC { get; set; }
        public void Register(SmartContract smartContract)
        {
            if(!smartContract.Miners.Contains(this))
            {
                smartContract.Miners.Add(this);
            } else {
                throw new Exception("Miner already registered to smart contract");
            }
        }
    }
}