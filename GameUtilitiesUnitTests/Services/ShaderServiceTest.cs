using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Services;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.Message;

namespace GameUtilitiesUnitTests.Services
{
    /// <summary>
    /// Test of the ShaderService class
    /// </summary>
    [TestClass]
    public class ShaderServiceTest
    {
        /// <summary>
        /// Test of the ShaderService init method
        /// Verify it registers for Topics
        /// </summary>
        [TestMethod]
        public void ShaderServiceInitTest()
        {
            ShaderService target = new ShaderService();
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);

            target.Init(execContextMock.Object);

            msgRouterMock.Verify(f => f.RegisterTopic(MessagingConstants.SHADER_SERVICE_TOPIC,target));
        }

        /// <summary>
        /// Test of the ShaderService terminate method
        /// Verify it deregisters for topics
        /// </summary>
        [TestMethod]
        public void ShaderServiceTerminateTest()
        {
            ShaderService target = new ShaderService();
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
            target.Init(execContextMock.Object);

            target.Terminate();

            msgRouterMock.Verify(f => f.DeregisterTopic(MessagingConstants.SHADER_SERVICE_TOPIC, target));
        }
    }
}
