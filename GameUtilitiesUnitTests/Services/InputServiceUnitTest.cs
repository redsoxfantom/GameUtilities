using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameUtilities.Services;
using GameUtilitiesUnitTests.UnitTestUtilities;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using Moq;
using GameUtilities.Framework.Utilities.ExecutableContext;
using System.Collections.Generic;
using OpenTK.Input;
using GameUtilities.Framework.Utilities.Message;
using GameUtilities.Framework.Utilities.InputHandlers;

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
        /// Mocked out interface for InputHandlers
        /// </summary>
        private Mock<IInputHandler> handlerMock;

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
            handlerMock = new Mock<IInputHandler>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
            po.SetFieldOrProperty("mLogger", logger);
            po.SetFieldOrProperty("handler", handlerMock.Object);
            target.Init(execContextMock.Object);
        }

        /// <summary>
        /// Test the InputService when no topic is defined for a keypress
        /// </summary>
        [TestMethod]
        public void TestKeypressNoTopicDefined()
        {
            Dictionary<Key, string> KeyTopicDictionary = new Dictionary<Key, string>();
            po.SetFieldOrProperty("KeyTopicDictionary", KeyTopicDictionary);
            handlerMock.Setup(f => f.isKeyDown(Key.A)).Returns(true);

            target.Update(0, new Dictionary<string, List<IMessage>>());

            msgRouterMock.Verify(f => f.SendMessage(It.IsAny<string>(), It.IsAny<IMessage>()), Times.Never());
        }

        /// <summary>
        /// Test the InputService when a topic is defined for a keypress
        /// </summary>
        [TestMethod]
        public void TestKeypressWithTopicDefined()
        {
            Dictionary<Key, string> KeyTopicDictionary = new Dictionary<Key, string>();
            KeyTopicDictionary.Add(Key.A, "A_PRESSED");
            po.SetFieldOrProperty("KeyTopicDictionary", KeyTopicDictionary);
            handlerMock.Setup(f => f.isKeyDown(Key.A)).Returns(true);

            target.Update(0, new Dictionary<string, List<IMessage>>());

            msgRouterMock.Verify(f => f.SendMessage("A_PRESSED", It.IsAny<KeypressMessage>()), Times.Once());
        }
    }
}
