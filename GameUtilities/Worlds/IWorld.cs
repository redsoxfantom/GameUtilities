using GameUtilities.Entities;
using GameUtilities.Framework.Loggers;

namespace GameUtilities.Worlds
{
    /// <summary>
    /// An interface to the game World (a container for entities)
    /// </summary>
    public interface IWorld
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
        void Init();

        /// <summary>
        /// Call "Update" on all Entities
        /// </summary>
        /// <param name="timeSinceLastUpdate">Time since Update was called</param>
        void Update(double timeSinceLastUpdate);

        /// <summary>
        /// Call "Draw" on all Entities
        /// </summary>
        /// <param name="timeSinceLastUpdate">Time since Draw was called</param>
        void Draw(double timeSinceLastUpdate);
    }
}
