using System;

namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// Interface for any object that can receive a message
    /// </summary>
    public interface IMessageDestination
    {
        /// <summary>
        /// Handle a direct message from the message router
        /// It is important to note that this is intended for direct messages only.
        /// That is, messages that need to be handled as soon as they are sent.
        /// Otherwise, it is better to queue up the message to be handled at the destination object's convenience.
        /// </summary>
        /// <param name="Topic">The topic of the message</param>
        /// <param name="message">The sent message</param>
        /// <param name="returnValue">An object containing the return value</param>
        /// <returns>Whether the message was handled or not</returns>
        bool HandleMessage(String Topic, IMessage message, ref object returnValue);
    }
}
