﻿using System;
using System.Text;

namespace CommonInterfaces
{
    public class Client : IClient
    {
        public int ClientId { get; set; } = -1;
        public DateTime CreationTime { get; } = DateTime.Now;

        public async Task Register()
        {
            var conService = new ClientConnectionService();
            Client client = (Client)await conService.Register();
            this.ClientId = client!.ClientId;
        }

        public void SendDataToSmartContract()
        {
            
        }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("================================================");
            sb.AppendLine("|                  CLIENT                      |");
            sb.AppendLine("|==============================================|");
            sb.AppendLine($"|- Client Id: {ClientId}");
            sb.AppendLine($"|- Creation Time: {CreationTime}");
            sb.AppendLine("================================================");


            return sb.ToString();
        }
    }
}
