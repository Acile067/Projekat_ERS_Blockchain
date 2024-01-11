using System.Text;
using System.Security.Cryptography;


namespace CommonInterfaces
{
    public class Block : IBlock
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
        public int PreviousBlockId { get; set; }

        
        public Block(int id, string data, int previousBlockId)
        {
            Id = id;
            Data = data;
            PreviousBlockId = previousBlockId;
            Hash = CalculateHash();
        }

        
        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                
                string rawData = $"{Id}{Data}{PreviousBlockId}";
                
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

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
