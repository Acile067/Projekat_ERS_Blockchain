using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CommonInterfaces.Services
{
    public class MinerRCV_Service
    {
        private readonly TcpListener listener;

        public MinerRCV_Service()
        {
            listener = new TcpListener(IPAddress.Any, 8081); 
            listener.Start();

            
            Task.Run(() => ListenForMinerConnections());
        }

        public async Task ListenForMinerConnections()
        {
            while (true)
            {
                TcpClient clientHandler = await listener.AcceptTcpClientAsync();
                _ = HandleMinerConnection(clientHandler);
            }
        }

        private async Task HandleMinerConnection(TcpClient clientHandler)
        {
            byte[] buffer = new byte[512];

            var stream = clientHandler.GetStream();
            int length = await stream.ReadAsync(buffer);
            var msgType = Encoding.UTF8.GetString(buffer, 0, length);

            switch (msgType)
            {
                case "UPDATED_LIST":
                    await stream.WriteAsync(Encoding.UTF8.GetBytes("OK"));
                    length = await stream.ReadAsync(buffer);
                    string jsonUpdatedList = Encoding.UTF8.GetString(buffer, 0, length);
                    var updatedList = JsonSerializer.Deserialize<List<IUser>>(jsonUpdatedList);

                    foreach (var miner in updatedList.OfType<Miner>())
                    {
                        Console.WriteLine(miner);
                    }
                    break;
                default:
                    break;
            }

            
            clientHandler.Close();
        }

        public async static void SendUpdatedList(List<IUser> registeredUsers)
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(IPAddress.Loopback, 8081); 

            var stream = tcpClient.GetStream();
            var buffer = new byte[8];

            await stream.WriteAsync(Encoding.UTF8.GetBytes("UPDATED_LIST"));
            int length = await stream.ReadAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, length);

            if (response == "OK")
            {
                var json = JsonSerializer.Serialize<List<IUser>>(registeredUsers);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(json));
            }

            
            tcpClient.Close();
        }
    }
}
