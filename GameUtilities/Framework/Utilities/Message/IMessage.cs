namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// The interface for Message objects
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Initialize the Message
        /// </summary>
        void Init();

        /// <summary>
        /// Gets the data associated with the message
        /// </summary>
        /// <returns>a data object</returns>
        object GetData();
    }
}
