using CommonInterfaces;

namespace Tests
{
    public class ClientRegisterServiceMockup : IRegisterable
    {
        public async Task<IUser?> Register()
        {
            await Task.Delay(100);
            var client = new Client
            {
                ClientId = 10
            };
            return client;
        }
    }
}
