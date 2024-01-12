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
            Console.WriteLine("Listening...");
            while(true)
            {
                await _conService.ReceieveMessage(userId++, registeredUsers);
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
