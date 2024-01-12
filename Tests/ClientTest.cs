using NUnit.Framework;
using Moq;
using ClientNamespace;
using CommonInterfaces;

namespace Tests
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public async Task Client_HasValidIndexWhenRegisters()
        {
            var client = new Client();
            var regService = new ClientRegisterServiceMockup();
            await client.Register(regService);
            Assert.That(client.ClientId, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Client_HasInvalidIdWhenNotRegistered()
        {
            var client = new Client();
            Assert.That(client.ClientId, Is.LessThan(0));
        }

        [Test]
        public void HandleUI_ThrowsExceptionWhenClientIsNull()
        {
            // Arrange
            IClient nullClient = null;
            var uiHandler = new ClientUIHandler(nullClient);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => uiHandler.HandleUI());
        }
    }
}