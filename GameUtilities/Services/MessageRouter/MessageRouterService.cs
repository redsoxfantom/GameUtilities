using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Framework.Utilities.Message;
using GameUtilities.Services;
using System.Collections.Generic;

namespace GameUtilities.Services.MessageRouter
{
    /// <summary>
    /// The message router service.
    /// Uses a subscription-based model where Components and Services can register for Topics, and then retrieve Messages each Frame
    /// </summary>
    public class MessageRouterService : IMessageRouterService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// The constructor
        /// </summary>
        public MessageRouterService()
        {
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
            throw new System.NotImplementedException();
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
