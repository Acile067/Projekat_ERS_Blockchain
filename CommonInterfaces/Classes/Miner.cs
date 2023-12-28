
using CommonInterfaces.Services;
using System.Text;

namespace CommonInterfaces
{
    public class Miner : IMiner
    {
        public int MinerId { get; set; } = -1;
        public double BTC { get; set; }

        public int GetId()
        {
            return MinerId;
        }

        public async Task Register()
        {
            var regService = new MinerRegisterService();
            Miner miner = (Miner)await regService.Register();
            this.MinerId = miner!.MinerId;      
            this.BTC = 0;
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("================================================");
            sb.AppendLine("|                  MINER                       |");
            sb.AppendLine("|==============================================|");
            sb.AppendLine($"|- Miner Id: {MinerId}");
            sb.AppendLine($"|- BTC: {BTC}");
            sb.AppendLine("================================================");


            return sb.ToString();
        }
    }
}