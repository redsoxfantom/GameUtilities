using GameUtilities.Entities;

namespace GameUtilities.Framework
{
    /// <summary>
    /// Stores entity-level information
    /// </summary>
    class ExecutableContext
    {
        /// <summary>
        /// The Entity the context is associated with
        /// </summary>
        public IEntity Entity { private set; public get; }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="entity">The entity the context is associated with</param>
        public ExecutableContext(IEntity entity)
        {
            Entity = entity;
        }
    }
}
