using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace P1_Blockchain.Blocks.impl
{
    public class Blocksimpl : IBlocks
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Hash { get; private set; }
        public int PreviousBlockId { get; set; }

        // Constructor
        public Blocksimpl(int id, string data, int previousBlockId)
        {
            Id = id;
            Data = data;
            PreviousBlockId = previousBlockId;
            Hash = ((IBlocks)this).CalculateHash();
        }

        // Method to calculate SHA256 hash

        string IBlocks.CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Combine block data and previous block's hash
                string rawData = $"{Id}{Data}{PreviousBlockId}";

                // Compute hash
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert hash bytes to string
                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashBuilder.Append(b.ToString("x2"));
                }

                return hashBuilder.ToString();
            }
        }
    }
}
