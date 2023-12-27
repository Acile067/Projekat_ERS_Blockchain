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
        public async Task<IUser?> GetUser(int id) 
        {   
            TcpClient clientHandler = await listener.AcceptTcpClientAsync();
            byte[] buffer = new byte[512];

            var stream = clientHandler.GetStream();
            int length = await stream.ReadAsync(buffer);
            var msgType = Encoding.UTF8.GetString(buffer, 0, length);

            if(msgType == "CLIENT")
            {
                var newClient = new Client { ClientId = id };
                var jsonClient = JsonSerializer.Serialize<Client>(newClient);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonClient));
                return newClient;
            }

            else if(msgType == "MINER")
            {
                var newMiner = new Miner();
                //TODO: resi majnera
            }
            return null;
        }
    }
}