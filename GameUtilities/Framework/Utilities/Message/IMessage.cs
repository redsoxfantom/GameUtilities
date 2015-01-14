namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// The interface for Message objects
    /// </summary>
    public interface IMessage<T>
    {
        /// <summary>
        /// Initialize the Message
        /// </summary>
        void Init(T obj);

        /// <summary>
        /// Gets the data associated with the message
        /// </summary>
        /// <returns>a data object</returns>
        T GetData();
    }
}
