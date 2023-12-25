using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using P1_Blockchain.Client;
using P1_Blockchain.SmartContract;

namespace P1_Blockchain{
    public class ConnectionService : IConnectionService
    {   
        private readonly TcpListener listener;

        public ConnectionService()
        {
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
        }
        public async Task<IClient> GetClient() 
        {   
            TcpClient clientHandler = await this.listener.AcceptTcpClientAsync();
            byte[] buffer = new byte[1_024];

            var stream = clientHandler.GetStream();
            await stream.ReadAsync(buffer);
            var dummyClient = "{\"id\":2, \"data\":\"gugu gaga\"}";
            var client = JsonSerializer.Deserialize<Client.Client>(JsonDocument.Parse(dummyClient));
            return client;
        }

        public async void SendClient(IClient client)
        {   
            try
            {
                var tcpClient = new TcpClient(AddressFamily.InterNetwork);
                await tcpClient.ConnectAsync(IPAddress.Loopback, 8080);
                var stream = tcpClient.GetStream();
                var clientJson = JsonSerializer.Serialize<IClient>(client);
                await stream.WriteAsync(ASCIIEncoding.UTF8.GetBytes(clientJson));
            } 
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }
    }
}