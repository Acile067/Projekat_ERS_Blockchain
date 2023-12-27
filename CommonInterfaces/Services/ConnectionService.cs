using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;



namespace CommonInterfaces
{
    public class ConnectionService : IConnectionService
    {   
        private readonly TcpListener listener;

        public ConnectionService()
        {
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
        }
        public async Task<IUser?> ReceieveMessage(int id) 
        {   
            TcpClient clientHandler = await listener.AcceptTcpClientAsync();
            byte[] buffer = new byte[512];

            var stream = clientHandler.GetStream();
            int length = await stream.ReadAsync(buffer);
            var msgType = Encoding.UTF8.GetString(buffer, 0, length);
            switch(msgType)
            {
                case "CLIENT":
                    var newClient = new Client { ClientId = id };
                    var jsonClient = JsonSerializer.Serialize<Client>(newClient);
                    await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonClient));
                    return newClient;
                case "MINER":
                    var newMiner = new Miner();
                    //TODO: resi majnera
                    break;
                case "DATA":
                    length = await stream.ReadAsync(buffer);
                    string jsonData = Encoding.UTF8.GetString(buffer, 0, length);
                    var dataMessage = JsonSerializer.Deserialize<DataMessage>(jsonData);
                    Console.WriteLine($"Got a message: {dataMessage!.Data}");
                    break;
                default:
                    break;
            }
            return null;
        }

        public async static void SendMessage(DataMessage msg)
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(IPAddress.Loopback, 8080);
            var stream = tcpClient.GetStream();
            var buffer = new byte[512];

            await stream.WriteAsync(Encoding.UTF8.GetBytes("DATA"));
            
            var json = JsonSerializer.Serialize<DataMessage>(msg);
            await stream.WriteAsync(Encoding.UTF8.GetBytes(json));
        }
    }
}