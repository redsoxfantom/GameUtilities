using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Framework.Utilities.Message;
using GameUtilities.Services;
using System.Collections.Generic;

namespace GameUtilities.Framework.Utilities.Message.MessageDispatch
{
    /// <summary>
    /// The message router service.
    /// Uses a subscription-based model where Components and Services can register for Topics, and then retrieve Messages each Frame.
    /// The messages are maintained in a double-buffer pattern, where messages sent this frame are not available until next frame
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
        /// Messages that will be returned this frame
        /// Any messages retrieved from GetMessages come from this Dictionary
        /// </summary>
        private Dictionary<string, List<IMessage>> mCurrentFrameMessages;

        /// <summary>
        /// Messages that are being stored for the next frame
        /// Any messages passed through SendMessage are stored here
        /// </summary>
        private Dictionary<string, List<IMessage>> mNextFrameMessages;

        /// <summary>
        /// The constructor
        /// </summary>
        public MessageRouter()
        {
            ConsumerTopicDictionary = new Dictionary<IMessageDestination, List<string>>();
            TopicConsumerDictionary = new Dictionary<string, List<IMessageDestination>>();
            mCurrentFrameMessages = new Dictionary<string, List<IMessage>>();
            mNextFrameMessages = new Dictionary<string, List<IMessage>>();
            mLogger = LoggerFactory.CreateLogger("MessageRouter");
            mLogger.Info("Created Message Router");
        }

        /// <summary>
        /// Get all messages for subscribed topics
        /// </summary>
        /// <returns>A dictionary of topics and list of messages associated with the topic</returns>
        public Dictionary<string, List<IMessage>> GetMessages(IMessageDestination consumer)
        {
            if(!ConsumerTopicDictionary.ContainsKey(consumer))
            {
                return new Dictionary<string,List<IMessage>>();
            }
            List<string> subscribedTopics = ConsumerTopicDictionary[consumer];
            Dictionary<string, List<IMessage>> returnDict = new Dictionary<string, List<IMessage>>();

            foreach(string Topic in subscribedTopics)
            {
                if(mCurrentFrameMessages.ContainsKey(Topic))
                {
                    returnDict.Add(Topic, mCurrentFrameMessages[Topic]);
                }
            }

            return returnDict;
        }

        /// <summary>
        /// Register to receive Messages pertaining to a Topic
        /// </summary>
        /// <param name="Topic">The topic to subscribe for</param>
        /// <param name="consumer">The object that is subscribing for this Topic</param>
        public void RegisterTopic(string Topic, IMessageDestination consumer)
        {
            mLogger.Debug(string.Format("Consumer {0} registered for topic {1}",consumer.GetType(),Topic));

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
            mLogger.Debug(string.Format("Consumer {0} deregistered for topic {1}", consumer.GetType(), Topic));

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
            if(mNextFrameMessages.ContainsKey(Topic))
            {
                mNextFrameMessages[Topic].Add(message);
            }
            else
            {
                List<IMessage> list = new List<IMessage>();
                list.Add(message);
                mNextFrameMessages.Add(Topic, list);
            }
        }

        /// <summary>
        /// Send a message to one subscriber. The recepient will handle it immediately
        /// If there are multiple subscribers, the first will handle it, and move to the end of the line (like a queue)
        /// </summary>
        /// <param name="Topic">The topic to associate with this message</param>
        /// <param name="message">The message to send</param>
        /// <param name="ReturnValue">An object to return</param>
        /// <returns>Whether or not the message successfully went through</returns>
        public bool SendMessageImmediate(string Topic, IMessage message, ref object ReturnValue)
        {
            if(TopicConsumerDictionary.ContainsKey(Topic))
            {
                IMessageDestination dest = TopicConsumerDictionary[Topic][0];
                TopicConsumerDictionary[Topic].Remove(dest);
                TopicConsumerDictionary[Topic].Add(dest);

                return dest.HandleMessage(message, ref ReturnValue);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set the current dictionary to the next one
        /// </summary>
        public void Update()
        {
            mCurrentFrameMessages = mNextFrameMessages;
            mNextFrameMessages = new Dictionary<string, List<IMessage>>();
        }
    }
}
