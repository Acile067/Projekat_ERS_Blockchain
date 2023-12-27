
namespace CommonInterfaces
{
    public class Miner : IMiner
    {
        public int Id { get; set; }
        public double BTC { get; set; }

        public int GetId()
        {
            return Id;
        }

        public Task Register()
        {
            throw new NotImplementedException();
        }
    }
}