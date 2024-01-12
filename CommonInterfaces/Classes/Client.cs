using System;
using System.Text;
using System.Text.Json;

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
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
