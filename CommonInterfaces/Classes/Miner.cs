
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

        public Block CreateBlock(int idb,string data, int previousBlockId)
        {
            int id = idb; 
            Block block = new Block(id, data, previousBlockId);
            string hash = block.Hash;

            while (!hash.StartsWith("000"))
            {
                block.Data += "NONCE"; 
                hash = block.CalculateHash();
            }

            block.Hash = hash;
            Console.WriteLine($"Created block with hash: {hash}");

            return block;
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