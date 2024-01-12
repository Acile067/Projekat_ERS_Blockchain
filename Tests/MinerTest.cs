using CommonInterfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MinerTest
    {
        [Test]
        public async Task Miner_HasValidIndexWhenRegistered()
        {
            var miner = new Miner();
            var regService = new MinerRegisterServiceMockup();
            await miner.Register(regService);
            Assert.That(miner.MinerId, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
         public void Miner_HasInvalidIdWhenNotRegistered()
        {
            var miner = new Miner();
            Assert.That(miner.MinerId, Is.LessThan(0));
        }

        [Test]
        public void Miner_CalculatesHashCorrectly()
        {
            var miner = new Miner();
            var block = miner.CreateBlock(new DataMessage { Data = "Test"});
            Assert.That(block.Data.Data.StartsWith("000"));
        }

        public void Miner_GetsAwardedBTC()
        {
            var miner = new Miner();
            _ = miner.CreateBlock(new DataMessage { Data = "Test"});
            Assert.That(miner.BTC, Is.GreaterThan(0));
        }
    }
}