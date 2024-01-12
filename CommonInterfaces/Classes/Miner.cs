
using CommonInterfaces.Services;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces
{
    public class Miner : IMiner
    {
        public int MinerId { get; set; } = -1;
        public double BTC { get; set; }

        public List<Block> blockchain = [];

        public int currentBlockId = 0;

        public int previousBlockId = -1;

        public int GetId()
        {
            return MinerId;
        }

        public async Task Register()
        {
            var regService = new MinerRegisterService();
            Miner? miner = (Miner?)await regService.Register();
            this.MinerId = miner!.MinerId;      
            this.BTC = 0;
        }

        public Block CreateBlock(DataMessage data)
        {
            Block block = new Block(currentBlockId++, data, previousBlockId++, MinerId);

            while (!block.Hash.StartsWith("000"))
            {
                block.nonce++; 
                block.CalculateHash();
            }
            BTC += 0.1;
            
            return block;
        }

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions{ WriteIndented = true} );
        }

        public List<Block> GetBlockChain()
        {
            return blockchain;
        }
    }
}