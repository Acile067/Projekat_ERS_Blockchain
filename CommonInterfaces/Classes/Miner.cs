
namespace CommonInterfaces
{
    public class Miner : IMiner
    {
        public int Id { get; set; }
        public double BTC { get; set; }

        public void Register(ISmartContract smartContract)
        {
            throw new System.NotImplementedException();
        }

        public Task Register()
        {
            throw new NotImplementedException();
        }
    }
}