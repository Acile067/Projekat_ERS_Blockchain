using CommonInterfaces;

namespace Tests
{
    public class ClientRegisterServiceMockup : IRegisterable
    {
        public async Task<IUser?> Register()
        {
            await Task.Delay(100);
            var client = new Client();
            client.ClientId = 10;
            return client;
        }
    }
}
