using System;
using System.Text;

namespace CommonInterfaces
{
    public class Client : IClient
    {
        public int ClientId { get; set; } = -1;
        public DateTime CreationTime { get; } = DateTime.Now;

        public int GetId()
        {
            return ClientId;
        }

        public async Task Register()
        {
            var regService = new ClientRegisterService();
            Client client = (Client)await regService.Register();
            this.ClientId = client!.ClientId;
        }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("================================================");
            sb.AppendLine("|                  CLIENT                      |");
            sb.AppendLine("|==============================================|");
            sb.AppendLine($"|- Client Id: {ClientId}");
            sb.AppendLine($"|- Creation Time: {CreationTime}");
            sb.AppendLine("================================================");


            return sb.ToString();
        }
    }
}
