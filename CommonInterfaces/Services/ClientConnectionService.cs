using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces
{
    public class ClientConnectionService : IConnectionService
    {
        public Task<IClient> GetClient()
        {
            throw new NotImplementedException();
        }

        public async void SendClient(IClient client)
        {
            try
            {
                var tcpClient = new TcpClient(AddressFamily.InterNetwork);
                tcpClient.Connect(IPAddress.Loopback, 8080);
                var stream = tcpClient.GetStream();
                var clientJson = JsonSerializer.Serialize<Client>(client as Client);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(clientJson));
            } 
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }
    }
}
