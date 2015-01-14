namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// The base class for Messages
    /// </summary>
    public class BaseMessage : IMessage
    {
        /// <summary>
        /// The object
        /// </summary>
        private object mObj;

        /// <summary>
        /// The constructor
        /// </summary>
        public BaseMessage()
        {

        }

        /// <summary>
        /// Initialize the Message
        /// </summary>
        public virtual void Init(object obj)
        {
            mObj = obj;
        }

        /// <summary>
        /// Gets the message's data
        /// </summary>
        /// <returns>a data object</returns>
        public virtual object GetData()
        {
            return mObj;
        }
    }
}
