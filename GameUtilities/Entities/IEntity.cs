using GameUtilities.Components;
using GameUtilities.Framework;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Framework.Utilities.Message;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Represents an object in the game world
    /// </summary>
    public interface IEntity : IDrawable, IUpdatable, ITerminatable, IMessageDestination
    {
        /// <summary>
        /// The entities' unique name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Initializes the Entity
        /// </summary>
        void Init(IExecutableContext Context);
    }
}
