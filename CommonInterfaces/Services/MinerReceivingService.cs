

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CommonInterfaces
{
    public class MinerReceivingService : IListReceiver
    {
        public async Task<List<Miner>?> Receive(CancellationToken token)
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(address: IPAddress.Loopback, port: 8080);
            var stream = tcpClient.GetStream();
            var buffer = new byte[10_240];
            var length = await stream.ReadAsync(buffer, token);
            string response = Encoding.UTF8.GetString(buffer, 0, length);
            switch(response)
            {
                case "MINER":
                    await stream.WriteAsync(Encoding.UTF8.GetBytes("OK"));
                    length = await stream.ReadAsync(buffer, token);
                    response = Encoding.UTF8.GetString(buffer, 0, length);
                    List<Miner> minerList = JsonSerializer.Deserialize<List<Miner>>(response);
                    Console.WriteLine($"Received {(minerList != null ? minerList.Count : "no")} miners");
                    return minerList;
                
                case "DATA":
                    await stream.WriteAsync(Encoding.UTF8.GetBytes("OK"));
                    length = await stream.ReadAsync(buffer, token);
                    response = Encoding.UTF8.GetString(buffer, 0, length);
                    DataMessage msg = JsonSerializer.Deserialize<DataMessage>(response);
                    Console.WriteLine(msg.Data);
                    break;
                default:
                    break;
            }
            return null;
            
        }
    }
}