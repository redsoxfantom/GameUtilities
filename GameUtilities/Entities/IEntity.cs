using GameUtilities.Components;
using GameUtilities.Framework;
using GameUtilities.Framework.Loggers;
using GameUtilities.Entities.DataContracts;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Represents an object in the game world
    /// </summary>
    public interface IEntity : IDrawable, IUpdatable, ITerminatable
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
    }
}
