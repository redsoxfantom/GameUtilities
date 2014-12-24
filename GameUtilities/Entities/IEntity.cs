using GameUtilities.Components;
using GameUtilities.Framework;
using GameUtilities.Framework.Loggers;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Represents an object in the game world
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The Entities' logger
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// The entities' unique name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Initializes the Entity
        /// </summary>
        void Init(ExecutableContext Context);

        /// <summary>
        /// Calls "Update" on all components attached to the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        void Update(double timeSinceLastFrame);

        /// <summary>
        /// Calls "Draw" on all componets attached to the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Draw was called</param>
        void Draw(double timeSinceLastFrame);
    }
}
