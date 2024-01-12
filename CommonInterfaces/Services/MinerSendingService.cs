
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces 
{
    public class MinerSendingService : ISender
    {
        public async Task SendBlock(Block block)
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(address: IPAddress.Loopback, port: 8080);
            var buffer = new byte[1024];
            var stream = tcpClient.GetStream();
            await stream.WriteAsync(Encoding.UTF8.GetBytes("BLOCK"));

            var length = await stream.ReadAsync(buffer);
            
            string response = Encoding.UTF8.GetString(buffer, 0, length);
            if(response == "OK")
            {
                var jsonBlock = JsonSerializer.Serialize(block);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonBlock));
            }
        }
    }
}
