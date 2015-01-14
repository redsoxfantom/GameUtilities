namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// The base class for Messages
    /// </summary>
    public class BaseMessage<T> : IMessage<T>
    {
        /// <summary>
        /// The object
        /// </summary>
        private T mObj;

        /// <summary>
        /// The constructor
        /// </summary>
        public BaseMessage()
        {

        }

        /// <summary>
        /// Initialize the Message
        /// </summary>
        public virtual void Init(T obj)
        {
            mObj = obj;
        }

        /// <summary>
        /// Gets the message's data
        /// </summary>
        /// <returns>a data object</returns>
        public virtual T GetData()
        {
            return mObj;
        }
    }
}
