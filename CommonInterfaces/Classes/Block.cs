using System.Text;
using System.Security.Cryptography;
using System.Text.Json;


namespace CommonInterfaces
{
    public class Block : IBlock
    {
        public int Id { get; set; }
        public DataMessage Data { get; set; }
        public string Hash { get; set; }
        public int PreviousBlockId { get; set; }
        public UInt128 nonce = 0; 
        
        public Block(int id, DataMessage data, int previousBlockId)
        {
            Id = id;
            Data = data;
            PreviousBlockId = previousBlockId;
            Hash = "";
            CalculateHash();
        }

        
        public void CalculateHash()
        {
            using SHA256 sha256 = SHA256.Create();

            string rawData = JsonSerializer.Serialize(this);

            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder hashBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashBuilder.Append(b.ToString("x2"));
            }

            this.Hash = hashBuilder.ToString();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true});
        }
    }
}
