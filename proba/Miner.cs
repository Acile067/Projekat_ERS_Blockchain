
using SmartContract;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public class Miner 
    {
        public int MinerId { get; set; } = -1;
        public double BTC { get; set; }
        public int idtest = 0;
        public int GetId()
        {
            return MinerId;
        }

        public void CreateBlock(string data, int previousBlockId)
        {
            int id = idtest++; // Get the next available block ID (logic for this is not shown)
            Block block = new Block(id, data, previousBlockId);
            string hash = block.Hash;

            // Keep trying with different nonces until the hash starts with three zeros
            while (!hash.StartsWith("000"))
            {
                // Modify the block data slightly (e.g., append a nonce)
                // You can experiment with different ways to modify the data to achieve the desired hash
                block.Data += "NONCE"; // Example modification
                hash = block.CalculateHash();
            }
            
            Console.WriteLine($"Created block with hash: {hash} data: {block.Data}");
            // Do something with the block, e.g., add it to a chain
        }

        public override string ToString()
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