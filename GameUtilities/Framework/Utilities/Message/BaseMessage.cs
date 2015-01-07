namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// The base class for Messages
    /// </summary>
    public class BaseMessage : IMessage
    {
        /// <summary>
        /// The constructor
        /// </summary>
        public BaseMessage()
        {

        }

        /// <summary>
        /// Initialize the Message
        /// </summary>
        public virtual void Init()
        { }

        /// <summary>
        /// Gets the message's data
        /// </summary>
        /// <returns>a data object</returns>
        public virtual object GetData()
        {
            return null;
        }
    }
}
