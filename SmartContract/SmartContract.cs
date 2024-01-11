using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CommonInterfaces;

namespace SmartContract
{
    public class SmartContract(IConnectionService conService) : ISmartContract
    {
        private List<IUser> registeredUsers = [];
        private int userId = 0;
        private IConnectionService _conService = conService;

        public async Task ListenForUsers(){
            while(true)
            {
                Console.WriteLine("Listening...");
                var user = await _conService.ReceieveMessage(userId);
                RegisterUser(user);
                if (user is Client)
                {
                    userId++;
                    Console.WriteLine($"Registered client \n{user as Client}");
                }
                else if (user is Miner)
                {
                    userId++;
                    Console.WriteLine($"Registered miner \n{user as Miner}");
                    List<Miner> miners = [];
                    foreach(Miner miner in registeredUsers.OfType<Miner>()){
                        miners.Add(miner);
                    }
                    var minersJson = JsonSerializer.Serialize<List<Miner>>(miners);
                    for(int i = 0; i < miners.Count(); i++){
                        await _conService.SendMinerList(minersJson);
                    }
                }
                else if (user is null) 
                {
                    
                }
            }
                
        }

        public void RegisterUser(IUser user)
        {
            registeredUsers.Add(user);
        }
        public List<IUser> GetRegistredUsers()
        {
            return registeredUsers;
        }
    }
}