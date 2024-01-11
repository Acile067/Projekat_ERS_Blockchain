using NUnit.Framework;
using Moq;
using ClientNamespace;
using CommonInterfaces;
using System;

namespace ClientTest
{
    [TestFixture]
    public class ClientUIHandlerTests
    {
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