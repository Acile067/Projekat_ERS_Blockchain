

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces
{
    public class MinerReceivingService : IReceiver
    {
        public async Task<DataMessage?> Receive()
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(address: IPAddress.Loopback, port: 8080);
            var buffer = new byte[1024];
            var stream = tcpClient.GetStream();
            await stream.WriteAsync(Encoding.UTF8.GetBytes("RECEIVE"));
            
            var length = await stream.ReadAsync(buffer);
            if(length > 1)
            {
                string response = Encoding.UTF8.GetString(buffer, 0, length);

                var msg = JsonSerializer.Deserialize<DataMessage>(response);
                
                return msg!;
            }
            else 
            {
                return null;
            }
        }
    }
}
