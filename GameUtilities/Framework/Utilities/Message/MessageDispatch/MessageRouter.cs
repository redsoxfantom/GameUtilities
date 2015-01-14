using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Framework.Utilities.Message;
using GameUtilities.Services;
using System.Collections.Generic;

namespace GameUtilities.Framework.Utilities.Message.MessageDispatch
{
    /// <summary>
    /// The message router service.
    /// Uses a subscription-based model where Components and Services can register for Topics, and then retrieve Messages each Frame
    /// </summary>
    public class MessageRouter : IMessageRouter
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// Dictionary linking Consumers to their Topics
        /// </summary>
        private Dictionary<IMessageDestination, List<string>> ConsumerTopicDictionary;

        /// <summary>
        /// Dictionary linking Topics to all consumers subscribed for them
        /// </summary>
        private Dictionary<string, List<IMessageDestination>> TopicConsumerDictionary;

        /// <summary>
        /// The constructor
        /// </summary>
        public MessageRouter()
        {
            ConsumerTopicDictionary = new Dictionary<IMessageDestination, List<string>>();
            TopicConsumerDictionary = new Dictionary<string, List<IMessageDestination>>();
            mLogger = LoggerFactory.CreateLogger("MessageRouter");
            mLogger.Info("Created Message Router");
        }

        /// <summary>
        /// Get all messages for subscribed topics
        /// </summary>
        /// <returns>A dictionary of topics and list of messages associated with the topic</returns>
        public Dictionary<string, List<IMessage>> GetMessages(IMessageDestination consumer)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Register to receive Messages pertaining to a Topic
        /// </summary>
        /// <param name="Topic">The topic to subscribe for</param>
        /// <param name="consumer">The object that is subscribing for this Topic</param>
        public void RegisterTopic(string Topic, IMessageDestination consumer)
        {
            if(ConsumerTopicDictionary.ContainsKey(consumer))
            {
                ConsumerTopicDictionary[consumer].Add(Topic);
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(Topic);
                ConsumerTopicDictionary.Add(consumer, list);
            }

            if(TopicConsumerDictionary.ContainsKey(Topic))
            {
                TopicConsumerDictionary[Topic].Add(consumer);
            }
            else
            {
                List<IMessageDestination> list = new List<IMessageDestination>();
                list.Add(consumer);
                TopicConsumerDictionary.Add(Topic, list);
            }
        }

        /// <summary>
        /// Deregister a consumer from a topic
        /// </summary>
        /// <param name="Topic">The topic to degister from</param>
        /// <param name="consumer">The consumer to deregister</param>
        public void DeregisterTopic(string Topic, IMessageDestination consumer)
        {
            if(ConsumerTopicDictionary.ContainsKey(consumer))
            {
                ConsumerTopicDictionary[consumer].Remove(Topic);
            }

            if(TopicConsumerDictionary.ContainsKey(Topic))
            {
                TopicConsumerDictionary[Topic].Remove(consumer);
            }
        }

        /// <summary>
        /// Send a message to anyone subscribed to a Topic. The recepients will get it next frame
        /// </summary>
        /// <param name="Topic">The topic to associate this message with</param>
        /// <param name="message">The message to send</param>
        public void SendMessage(string Topic, IMessage message)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Send a message to one subscriber. The recepient will handle it immediately
        /// </summary>
        /// <param name="Topic">The topic to associate with this message</param>
        /// <param name="message">The message to send</param>
        /// <param name="ReturnValue">An object to return</param>
        /// <returns>Whether or not the message successfully went through</returns>
        public bool SendMessageImmediate(string Topic, IMessage message, ref object ReturnValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
