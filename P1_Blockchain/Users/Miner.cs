
namespace P1_Blockchain
{
    public class Miner : IMiner
    {
        public int Id { get; set; }
        public double BTC { get; set; }

        public void Register(SmartContract smartContract)
        {
            throw new System.NotImplementedException();
        }
    }
}