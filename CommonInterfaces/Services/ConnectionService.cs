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
        Stack<DataMessage> msgBuffer = [];
        public ConnectionService()
        {
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
        }
        public async Task ReceieveMessage(int id, List<IUser> users) 
        {   
            TcpClient clientHandler = await listener.AcceptTcpClientAsync();
            _ = Task.Run(() => HandleClient(clientHandler, users, id) );
            
        }

        public void PushMessages(DataMessage msg, List<IUser> users) 
        {
            var miners = users.OfType<Miner>().ToList();
            miners.ForEach((m) =>
            {
                msgBuffer.Push(msg);
            });
        }

        public void SendMinerList(List<IUser> users)
        {
            var miners = users.OfType<Miner>().ToList();
            var jsonMiners = JsonSerializer.Serialize(miners, new JsonSerializerOptions { WriteIndented = true });
            var msg = new DataMessage { Data = jsonMiners, DateTime = DateTime.Now, UserId = -1, Type = MsgType.MINER_LIST };
            miners.ForEach((m) =>
            {
                msgBuffer.Push(msg);
            });
        }

        public async Task SendBackData(DataMessage msg, NetworkStream stream){
            var jsonMsg = JsonSerializer.Serialize(msg);
            await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonMsg));
        }

        public async static void SendMessage(DataMessage msg)
        {
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            tcpClient.Connect(IPAddress.Loopback, 8080);
            var stream = tcpClient.GetStream();
            var buffer = new byte[8];

            await stream.WriteAsync(Encoding.UTF8.GetBytes("DATA"));
            int length = await stream.ReadAsync(buffer);
            string response = Encoding.UTF8.GetString(buffer, 0, length);
            
            if(response == "OK")
            {
                var json = JsonSerializer.Serialize(msg);
                await stream.WriteAsync(Encoding.UTF8.GetBytes(json));
            }
        }

        private async void HandleClient(TcpClient client, List<IUser> users, int id)
        {
            byte[] buffer = new byte[512];

                var stream = client.GetStream();
                int length = await stream.ReadAsync(buffer);
                var msgType = Encoding.UTF8.GetString(buffer, 0, length);
                switch (msgType)
                {
                    case "CLIENT":
                        var newClient = new Client { ClientId = id };
                        var jsonClient = JsonSerializer.Serialize(newClient);
                        await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonClient));
                        Console.WriteLine($"Registered client: \n{newClient}\n");
                        users.Add(newClient);
                        break;
                    case "MINER":
                        var newMiner = new Miner { MinerId = id };
                        var jsonMiner = JsonSerializer.Serialize(newMiner);
                        await stream.WriteAsync(Encoding.UTF8.GetBytes(jsonMiner));
                        Console.WriteLine($"Registered miner: \n{newMiner}\n");
                        users.Add(newMiner);
                        SendMinerList(users);
                        break;

                    case "DATA":
                        await stream.WriteAsync(Encoding.UTF8.GetBytes("OK"));
                        length = await stream.ReadAsync(buffer);
                        string jsonData = Encoding.UTF8.GetString(buffer, 0, length);
                        var dataMessage = JsonSerializer.Deserialize<DataMessage>(jsonData);
                        Console.WriteLine($"Got a message: {dataMessage!.Data}");
                        msgBuffer.Push(dataMessage);
                        break;
                    
                    case "RECEIVE":
                        DataMessage? msg;
                        if(msgBuffer.TryPop(out msg))
                        {   
                            await SendBackData(msg, stream);
                        }
                        else
                        {
                            await stream.WriteAsync(Encoding.UTF8.GetBytes("0"));
                        }
                        break;
                    case "BLOCK":
                        await stream.WriteAsync(Encoding.UTF8.GetBytes("OK"));
                        length = await stream.ReadAsync(buffer);
                        string jsonBlock = Encoding.UTF8.GetString(buffer, 0, length);
                        var block = JsonSerializer.Deserialize<Block>(jsonBlock);
                        Console.WriteLine($"Received a new block with hash: {block!.Hash[..16]}\n");
                        (users.FirstOrDefault(x => x.GetId() == block.MinerId) as Miner)!.BTC += 0.1;
                        var data = new DataMessage { Data = jsonBlock, DateTime = DateTime.Now, Type = MsgType.BLOCK };
                        PushMessages(data, users);
                        break;
                    default:
                        break;
                }
        }
    }
}
