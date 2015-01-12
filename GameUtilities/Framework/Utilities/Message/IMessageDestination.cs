namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// Interface for any object that can receive a message
    /// </summary>
    interface IMessageDestination
    {
        /// <summary>
        /// Handle a message
        /// </summary>
        /// <param name="message">The sent message</param>
        /// <param name="returnValue">An object containing the return value</param>
        /// <returns>Whether the message was handled or not</returns>
        bool HandleMessage(IMessage message, ref object returnValue);
    }
}
