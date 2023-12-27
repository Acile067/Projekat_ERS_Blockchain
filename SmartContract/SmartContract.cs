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
                var user = await _conService.GetUser(userId++);
                if(user is Client) 
                {
                    Console.WriteLine($"Registered client \n{user as Client}");
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