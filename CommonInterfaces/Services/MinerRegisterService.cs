using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonInterfaces.Services
{
    public class MinerRegisterService : IRegisterable
    {
        public async Task<IUser?> Register()
        {
            using (var tcpMiner = new TcpClient(AddressFamily.InterNetwork))
            {
                try
                {
                    await tcpMiner.ConnectAsync(IPAddress.Loopback, 8080);
                    using (var stream = tcpMiner.GetStream())
                    {
                        var buffer = new byte[512];

                        await stream.WriteAsync(Encoding.UTF8.GetBytes("MINER"));
                        int length = await stream.ReadAsync(buffer);
                        string minerJson = Encoding.UTF8.GetString(buffer, 0, length);
                        var miner = JsonSerializer.Deserialize<Miner>(minerJson);
                        return miner;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection error: {0}", ex.Message);
                    throw;
                }
            }
        }
    }
}
