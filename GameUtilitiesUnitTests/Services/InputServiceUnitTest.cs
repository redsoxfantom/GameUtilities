using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameUtilities.Services;
using GameUtilitiesUnitTests.UnitTestUtilities;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using Moq;
using GameUtilities.Framework.Utilities.ExecutableContext;

namespace GameUtilitiesUnitTests.Services
{
    /// <summary>
    /// Test class for the InputService class
    /// </summary>
    [TestClass]
    public class InputServiceUnitTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private InputService target;

        /// <summary>
        /// Accessor to private methods/fields
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// The logger
        /// </summary>
        private LoggerUtility logger;

        /// <summary>
        /// Mock up of the message router
        /// </summary>
        private Mock<IMessageRouter> msgRouterMock;

        /// <summary>
        /// Mock up of the executable context
        /// </summary>
        private Mock<IExecutableContext> execContextMock;

        /// <summary>
        /// Handles first time setup of the test
        /// </summary>
        [TestInitialize]
        public void Initializze()
        {
            target = new InputService();
            po = new PrivateObject(target);
            logger = new LoggerUtility("test");
            msgRouterMock = new Mock<IMessageRouter>();
            execContextMock = new Mock<IExecutableContext>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
            po.SetFieldOrProperty("mLogger", logger);
            target.Init(execContextMock.Object);
        }
    }
}
