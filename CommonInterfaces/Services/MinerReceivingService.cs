

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
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(address: IPAddress.Loopback, port: 8080);
            var stream = tcpClient.GetStream();
            var buffer = new byte[10_240];
            var length = await stream.ReadAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, length);
            List<Miner> minerList = JsonSerializer.Deserialize<List<Miner>>(response);
            return minerList;
        }
    }
}