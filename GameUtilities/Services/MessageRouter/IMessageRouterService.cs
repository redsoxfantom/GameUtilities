using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Services.MessageRouter
{
    /// <summary>
    /// Interface for the message router
    /// </summary>
    public interface IMessageRouterService
    {
        /// <summary>
        /// Get all messages for subscribed topics
        /// </summary>
        /// <returns>A dictionary of topics and list of messages associated with the topic</returns>
        Dictionary<string,List<IMessage>> GetMessages();

        /// <summary>
        /// Register to receive Messages pertaining to a Topic
        /// </summary>
        /// <param name="Topic">The topic to subscribe for</param>
        /// <param name="consumer">The object that is subscribing for this Topic</param>
        void RegisterTopic(string Topic, IMessageDestination consumer);
    }
}
