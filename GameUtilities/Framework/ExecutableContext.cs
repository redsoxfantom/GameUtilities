using GameUtilities.Entities;
using GameUtilities.Framework.Loggers;
using GameUtilities.Worlds;

namespace GameUtilities.Framework
{
    /// <summary>
    /// Stores entity-level information
    /// </summary>
    public class ExecutableContext
    {
        /// <summary>
        /// The root World
        /// </summary>
        public IWorld World { set; get; }

        /// <summary>
        /// The Entity the context is associated with
        /// </summary>
        public IEntity Entity { set; get; }

        /// <summary>
        /// The constructor
        /// </summary>
        public ExecutableContext()
        {}
    }
}
