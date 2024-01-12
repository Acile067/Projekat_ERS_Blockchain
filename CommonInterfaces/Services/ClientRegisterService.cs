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
            using var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            try
            {
                await tcpClient.ConnectAsync(IPAddress.Loopback, 8080);
                using var stream = tcpClient.GetStream();
                var buffer = new byte[512];

                await stream.WriteAsync(Encoding.UTF8.GetBytes("CLIENT"));
                int length = await stream.ReadAsync(buffer);
                string clientJson = Encoding.UTF8.GetString(buffer, 0, length);
                var client = JsonSerializer.Deserialize<Client>(clientJson);
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection error: {0}", ex.Message);
                throw;
            }
        }
    }
}
