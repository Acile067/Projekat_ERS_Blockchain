using System.Text;
using System.Security.Cryptography;
using System;


namespace SmartContract
{
    public class Block 
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Hash { get; private set; }
        public int PreviousBlockId { get; set; }

        public int idtest = 0;

        // Constructor
        public Block(int id, string data, int previousBlockId)
        {
            Id = id;
            Data = data;
            PreviousBlockId = previousBlockId;
            Hash = CalculateHash();
        }

        // Method to calculate SHA256 hash
        public string CalculateHash()
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
