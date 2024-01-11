

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces
{
    public class MinerReceivingService : IListReceiver
    {
        public async Task<List<Miner>> Receive()
        {
            using (var tcpClient = new TcpClient(AddressFamily.InterNetwork))
            {
                try
                {
                    await tcpClient.ConnectAsync(IPAddress.Loopback, 8080);
                    using (var stream = tcpClient.GetStream())
                    {
                        var buffer = new byte[10_240];
                        var length = await stream.ReadAsync(buffer);
                        string response = Encoding.UTF8.GetString(buffer, 0, length);
                        List<Miner> minerList = JsonSerializer.Deserialize<List<Miner>>(response);
                        return minerList;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection error: {0}", ex.Message);
                    throw;
                }
            }
        }
    }
}