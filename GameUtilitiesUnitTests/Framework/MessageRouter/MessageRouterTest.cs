using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Framework.Utilities.Message.MessageDispatch
{
    /// <summary>
    /// Test for the Message Router service
    /// </summary>
    [TestClass]
    public class MessageRouterTest
    {
        /// <summary>
        /// Test for message registration
        /// </summary>
        [TestMethod]
        public void RegisterTopicTest()
        {
            MessageRouter target = new MessageRouter();
            PrivateObject obj = new PrivateObject(target);
            Dictionary<IMessageDestination, List<string>> ConsumerTopicDictionary = (Dictionary<IMessageDestination, List<string>>)obj.GetFieldOrProperty("ConsumerTopicDictionary");
            Dictionary<string, List<IMessageDestination>> TopicConsumerDictionary = (Dictionary<string, List<IMessageDestination>>)obj.GetFieldOrProperty("TopicConsumerDictionary");
            Mock<IMessageDestination> destMock1 = new Mock<IMessageDestination>();
            Mock<IMessageDestination> destMock2 = new Mock<IMessageDestination>();
            Mock<IMessageDestination> destMock3 = new Mock<IMessageDestination>();

            target.RegisterTopic("TEST1", destMock1.Object);
            target.RegisterTopic("TEST3", destMock1.Object);
            target.RegisterTopic("TEST2", destMock2.Object);
            target.RegisterTopic("TEST1", destMock3.Object);

            Assert.IsTrue(ConsumerTopicDictionary.ContainsKey(destMock1.Object));
            Assert.IsTrue(ConsumerTopicDictionary.ContainsKey(destMock2.Object));
            Assert.IsTrue(ConsumerTopicDictionary.ContainsKey(destMock3.Object));
            Assert.IsTrue(TopicConsumerDictionary.ContainsKey("TEST1"));
            Assert.IsTrue(TopicConsumerDictionary.ContainsKey("TEST2"));
            Assert.IsTrue(TopicConsumerDictionary.ContainsKey("TEST3"));
            List<string> dest1List = ConsumerTopicDictionary[destMock1.Object];
            Assert.IsTrue(dest1List.Count == 2);
            Assert.IsTrue(dest1List.Contains("TEST1"));
            Assert.IsTrue(dest1List.Contains("TEST3"));
            List<IMessageDestination> topic1List = TopicConsumerDictionary["TEST1"];
            Assert.IsTrue(topic1List.Count == 2);
            Assert.IsTrue(topic1List.Contains(destMock1.Object));
            Assert.IsTrue(topic1List.Contains(destMock3.Object));
            List<string> dest2List = ConsumerTopicDictionary[destMock2.Object];
            Assert.IsTrue(dest2List.Count == 1);
            Assert.IsTrue(dest2List.Contains("TEST2"));
            List<IMessageDestination> topic2List = TopicConsumerDictionary["TEST2"];
            Assert.IsTrue(topic2List.Count == 1);
            Assert.IsTrue(topic2List.Contains(destMock2.Object));
        }

        /// <summary>
        /// Test of the DeregisterTopic method
        /// </summary>
        [TestMethod]
        public void DeregisterTopicTest()
        {
            MessageRouter target = new MessageRouter();
            PrivateObject obj = new PrivateObject(target);
            Dictionary<IMessageDestination, List<string>> ConsumerTopicDictionary = (Dictionary<IMessageDestination, List<string>>)obj.GetFieldOrProperty("ConsumerTopicDictionary");
            Dictionary<string, List<IMessageDestination>> TopicConsumerDictionary = (Dictionary<string, List<IMessageDestination>>)obj.GetFieldOrProperty("TopicConsumerDictionary");
            Mock<IMessageDestination> destMock1 = new Mock<IMessageDestination>();
            Mock<IMessageDestination> destMock2 = new Mock<IMessageDestination>();
            Mock<IMessageDestination> destMock3 = new Mock<IMessageDestination>();

            target.RegisterTopic("TEST1", destMock1.Object);
            target.RegisterTopic("TEST3", destMock1.Object);
            target.RegisterTopic("TEST2", destMock2.Object);
            target.RegisterTopic("TEST1", destMock3.Object);
            target.DeregisterTopic("TEST1", destMock1.Object);

            List<string> dest1List = ConsumerTopicDictionary[destMock1.Object];
            Assert.IsTrue(dest1List.Count == 1);
            Assert.IsTrue(dest1List.Contains("TEST3"));
            List<IMessageDestination> topic1List = TopicConsumerDictionary["TEST1"];
            Assert.IsTrue(topic1List.Count == 1);
            Assert.IsTrue(topic1List.Contains(destMock3.Object));
            List<string> dest2List = ConsumerTopicDictionary[destMock2.Object];
            Assert.IsTrue(dest2List.Count == 1);
            Assert.IsTrue(dest2List.Contains("TEST2"));
            List<IMessageDestination> topic2List = TopicConsumerDictionary["TEST2"];
            Assert.IsTrue(topic2List.Count == 1);
            Assert.IsTrue(topic2List.Contains(destMock2.Object));
        }
    }
}
