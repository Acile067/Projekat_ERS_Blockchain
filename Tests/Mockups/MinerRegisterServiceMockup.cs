using CommonInterfaces;

namespace Tests
{
    public class MinerRegisterServiceMockup : IRegisterable
    {
        public async Task<IUser?> Register()
        {
            await Task.Delay(100);
            var miner = new Miner();
            miner.MinerId = 10;
            return miner;
        }
    }
}
