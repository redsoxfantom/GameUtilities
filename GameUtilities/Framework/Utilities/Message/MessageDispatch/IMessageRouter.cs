using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Framework.Utilities.Message.MessageDispatch
{
    /// <summary>
    /// Interface for the message router
    /// </summary>
    public interface IMessageRouter : ITerminatable
    {
        /// <summary>
        /// Get all messages for subscribed topics
        /// </summary>
        /// <returns>A dictionary of topics and list of messages associated with the topic</returns>
        Dictionary<string,List<IMessage>> GetMessages(IMessageDestination consumer);

        /// <summary>
        /// Register to receive Messages pertaining to a Topic
        /// </summary>
        /// <param name="Topic">The topic to subscribe for</param>
        /// <param name="consumer">The object that is subscribing for this Topic</param>
        void RegisterTopic(string Topic, IMessageDestination consumer);

        /// <summary>
        /// Deregister a consumer from a topic
        /// </summary>
        /// <param name="Topic">The topic to degister from</param>
        /// <param name="consumer">The consumer to deregister</param>
        void DeregisterTopic(string Topic, IMessageDestination consumer);

        /// <summary>
        /// Send a message to anyone subscribed to a Topic. The recepients will get it next frame
        /// </summary>
        /// <param name="Topic">The topic to associate this message with</param>
        /// <param name="message">The message to send</param>
        void SendMessage(string Topic, IMessage message);

        /// <summary>
        /// Send a message to one subscriber. The recepient will handle it immediately
        /// </summary>
        /// <param name="Topic">The topic to associate with this message</param>
        /// <param name="message">The message to send</param>
        /// <param name="ReturnValue">An object to return</param>
        /// <returns>Whether or not the message successfully went through</returns>
        bool SendMessageImmediate(string Topic, IMessage message, ref object ReturnValue);

        /// <summary>
        /// Update the message router. This swaps the current and next frame message queues
        /// </summary>
        void Update();
    }
}
