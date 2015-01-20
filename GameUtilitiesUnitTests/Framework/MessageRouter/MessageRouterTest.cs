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

        /// <summary>
        /// Test the SendMessageImmediate test
        /// </summary>
        [TestMethod]
        public void SendMessageImmediateTest()
        {
            MessageRouter target = new MessageRouter();
            PrivateObject obj = new PrivateObject(target);
            object ret = new object();
            Mock<IMessage> msgMock = new Mock<IMessage>();
            Dictionary<IMessageDestination, List<string>> ConsumerTopicDictionary = (Dictionary<IMessageDestination, List<string>>)obj.GetFieldOrProperty("ConsumerTopicDictionary");
            Dictionary<string, List<IMessageDestination>> TopicConsumerDictionary = (Dictionary<string, List<IMessageDestination>>)obj.GetFieldOrProperty("TopicConsumerDictionary");
            Mock<IMessageDestination> destMock1 = new Mock<IMessageDestination>();
            destMock1.Setup(f => f.HandleMessage("TEST1",msgMock.Object, ref ret)).Returns(true);
            Mock<IMessageDestination> destMock3 = new Mock<IMessageDestination>();
            destMock3.Setup(f => f.HandleMessage("TEST1", msgMock.Object, ref ret)).Returns(false);
            target.RegisterTopic("TEST1", destMock1.Object);
            target.RegisterTopic("TEST1", destMock3.Object);

            bool actual = target.SendMessageImmediate("TEST1", msgMock.Object, ref ret);
            Assert.IsTrue(actual);
            destMock1.Verify(f => f.HandleMessage("TEST1", msgMock.Object, ref ret), Times.Once());
            actual = target.SendMessageImmediate("TEST1", msgMock.Object, ref ret);
            Assert.IsFalse(actual);
            destMock3.Verify(f => f.HandleMessage("TEST1", msgMock.Object, ref ret), Times.Once());
            actual = target.SendMessageImmediate("TEST1", msgMock.Object, ref ret);
            Assert.IsTrue(actual);
            destMock1.Verify(f => f.HandleMessage("TEST1", msgMock.Object, ref ret), Times.Exactly(2));
        }

        /// <summary>
        /// Test for the send message method
        /// </summary>
        public void SendMessageTest()
        {
            MessageRouter target = new MessageRouter();
            PrivateObject obj = new PrivateObject(target);
            Mock<IMessage> msgMock = new Mock<IMessage>();
            Mock<IMessage> msgMock2 = new Mock<IMessage>();
            Mock<IMessage> msgMock3 = new Mock<IMessage>();
            Dictionary<string, List<IMessage>> mNextFrameMessages = (Dictionary<string, List<IMessage>>)obj.GetFieldOrProperty("mNextFrameMessages");

            target.SendMessage("TEST1", msgMock.Object);
            target.SendMessage("TEST2", msgMock2.Object);
            target.SendMessage("TEST1", msgMock3.Object);

            Assert.IsTrue(mNextFrameMessages.ContainsKey("TEST1"));
            Assert.IsTrue(mNextFrameMessages.ContainsKey("TEST2"));
            List<IMessage> actual = mNextFrameMessages["TEST1"];
            Assert.AreEqual(actual.Count, 2);
            Assert.IsTrue(actual.Contains(msgMock.Object));
            Assert.IsTrue(actual.Contains(msgMock3.Object));
            actual = mNextFrameMessages["TEST2"];
            Assert.AreEqual(actual.Count, 1);
            Assert.IsTrue(actual.Contains(msgMock2.Object));
        }

        /// <summary>
        /// Test for the GetMessages method
        /// </summary>
        [TestMethod]
        public void GetMessagesTest()
        {
            MessageRouter target = new MessageRouter();
            PrivateObject obj = new PrivateObject(target);
            Mock<IMessage> msgMock = new Mock<IMessage>();
            Mock<IMessage> msgMock2 = new Mock<IMessage>();
            Mock<IMessage> msgMock3 = new Mock<IMessage>();
            Mock<IMessage> msgMock4 = new Mock<IMessage>();
            Mock<IMessageDestination> destMock = new Mock<IMessageDestination>();
            Dictionary<string, List<IMessage>> mCurrentFrameMessages = (Dictionary<string, List<IMessage>>)obj.GetFieldOrProperty("mCurrentFrameMessages");
            Dictionary<IMessageDestination, List<string>> ConsumerTopicDictionary = (Dictionary<IMessageDestination, List<string>>)obj.GetFieldOrProperty("ConsumerTopicDictionary");
            List<string> topics = new List<string>();
            topics.Add("TEST1");
            topics.Add("TEST3");
            topics.Add("TEST4");
            ConsumerTopicDictionary.Add(destMock.Object, topics);
            List<IMessage> messages1 = new List<IMessage>();
            messages1.Add(msgMock.Object);
            messages1.Add(msgMock2.Object);
            List<IMessage> messages2 = new List<IMessage>();
            messages2.Add(msgMock3.Object);
            List<IMessage> messages3 = new List<IMessage>();
            messages3.Add(msgMock4.Object);
            mCurrentFrameMessages.Add("TEST1", messages1);
            mCurrentFrameMessages.Add("TEST2", messages2);
            mCurrentFrameMessages.Add("TEST3", messages3);

            Dictionary<string,List<IMessage>> actual = target.GetMessages(destMock.Object);

            Assert.IsTrue(actual.ContainsKey("TEST1"));
            Assert.IsTrue(actual.ContainsKey("TEST3"));
            Assert.IsFalse(actual.ContainsKey("TEST4"));
            List<IMessage> actual1 = actual["TEST1"];
            Assert.IsTrue(actual1.Count == 2);
            Assert.IsTrue(actual1.Contains(msgMock.Object));
            Assert.IsTrue(actual1.Contains(msgMock2.Object));
            List<IMessage> actual2 = actual["TEST3"];
            Assert.IsTrue(actual2.Count == 1);
            Assert.IsTrue(actual2.Contains(msgMock4.Object));
        }

        /// <summary>
        /// Test of the message router update test
        /// </summary>
        [TestMethod]
        public void MessageRouterUpdateTest()
        {
            MessageRouter target = new MessageRouter();
            PrivateObject obj = new PrivateObject(target);
            Mock<IMessage> msgMock = new Mock<IMessage>();
            Mock<IMessage> msgMock2 = new Mock<IMessage>();
            Dictionary<string, List<IMessage>> mNextFrameMessages = (Dictionary<string, List<IMessage>>)obj.GetFieldOrProperty("mNextFrameMessages");
            List<IMessage> messages1 = new List<IMessage>();
            messages1.Add(msgMock.Object);
            messages1.Add(msgMock2.Object);
            mNextFrameMessages.Add("TEST1", messages1);

            target.Update();

            Dictionary<string, List<IMessage>> mCurrentFrameMessages = (Dictionary<string, List<IMessage>>)obj.GetFieldOrProperty("mCurrentFrameMessages");
            mNextFrameMessages = (Dictionary<string, List<IMessage>>)obj.GetFieldOrProperty("mNextFrameMessages");

            Assert.IsTrue(mCurrentFrameMessages.ContainsKey("TEST1"));
            List<IMessage> actual = mCurrentFrameMessages["TEST1"];
            Assert.IsTrue(actual.Count == 2);
            Assert.IsTrue(actual.Contains(msgMock.Object));
            Assert.IsTrue(actual.Contains(msgMock2.Object));
            Assert.IsTrue(mNextFrameMessages.Count == 0);
        }
    }
}
