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
    public class ConnectionService 
    {
        public static async Task<IClient> GetClient() 
        {   
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            TcpClient clientHandler = await listener.AcceptTcpClientAsync();
            byte[] buffer = new byte[1_024];

            var stream = clientHandler.GetStream();
            await stream.ReadAsync(buffer);
            var client = JsonSerializer.Deserialize<Client.Client>(JsonDocument.Parse(buffer));
            return client;
        }

        public static async void SendClient(Client.Client client)
        {   
            try
            {
                var tcpClient = new TcpClient(AddressFamily.InterNetwork);
                await tcpClient.ConnectAsync(IPAddress.Loopback, 8080);
                var stream = tcpClient.GetStream();
                var clientJson = JsonSerializer.Serialize<Client.Client>(client);
                await stream.WriteAsync(ASCIIEncoding.UTF8.GetBytes(clientJson));
            } 
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }
    }
}