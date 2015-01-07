using GameUtilities.Entities;
using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework;
using GameUtilities.Worlds.DataContracts;

namespace GameUtilities.Worlds
{
    /// <summary>
    /// An interface to the game World (a container for entities)
    /// </summary>
    public interface IWorld : IUpdatable, IDrawable, ITerminatable
    {
        /// <summary>
        /// Get an entity given its unique ID (The entities name)
        /// </summary>
        /// <param name="entityId">The ID of the entity</param>
        /// <returns>a reference to the Entity</returns>
        IEntity GetEntity(string entityId);

        /// <summary>
        /// Initialize the World (Read in Entities and Components)
        /// </summary>
        void Init(IExecutableContext context);
    }
}
