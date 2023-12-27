using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces
{
    public class ClientRegisterService : IRegisterable
    {
        public async Task<IUser?> Register()
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(IPAddress.Loopback, 8080);
            var stream = tcpClient.GetStream();
            var buffer = new byte[512];
            
            await stream.WriteAsync(Encoding.UTF8.GetBytes("CLIENT"));
            int length = await stream.ReadAsync(buffer);
            string clientJson = Encoding.UTF8.GetString(buffer,0,length);
            var client = JsonSerializer.Deserialize<Client>(clientJson);
            return client;
        }
    }
}
