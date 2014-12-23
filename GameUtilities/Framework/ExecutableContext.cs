using GameUtilities.Entities;
using GameUtilities.Framework.Loggers;

namespace GameUtilities.Framework
{
    /// <summary>
    /// Stores entity-level information
    /// </summary>
    public class ExecutableContext
    {
        /// <summary>
        /// The Entity the context is associated with
        /// </summary>
        public IEntity Entity { set; get; }

        /// <summary>
        /// The World-level logger
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public ExecutableContext()
        {}
    }
}
