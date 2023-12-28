using System;
using System.Collections.Generic;
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
                if (user is Client)
                {
                    userId++;
                    Console.WriteLine($"Registered client \n{user as Client}");
                }
                else if (user is Miner)
                {
                    userId++;
                    Console.WriteLine($"Registered miner \n{user as Miner}");
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