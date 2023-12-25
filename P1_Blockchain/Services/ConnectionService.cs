using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


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
            TcpClient clientHandler = await listener.AcceptTcpClientAsync();
            byte[] buffer = new byte[1_024];

            var stream = clientHandler.GetStream();
            await stream.ReadAsync(buffer);
            var dummyClient = "{\"ClientId\":2, \"Data\":\"gugu gaga\"}";
            var client = JsonSerializer.Deserialize<Client>(JsonDocument.Parse(dummyClient));
            return client;
        }

        public async void SendClient(IClient client)
        {   
            try
            {
                var tcpClient = new TcpClient(AddressFamily.InterNetwork);
                await tcpClient.ConnectAsync(IPAddress.Loopback, 8080);
                var stream = tcpClient.GetStream();
                var clientJson = JsonSerializer.Serialize<Client>(client as Client);
                await stream.WriteAsync(ASCIIEncoding.UTF8.GetBytes(clientJson));
            } 
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }
    }
}