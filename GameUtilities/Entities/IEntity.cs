using GameUtilities.Components;
using GameUtilities.Framework;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Represents an object in the game world
    /// </summary>
    interface IEntity
    {
        /// <summary>
        /// Initializes the Entity
        /// 
        public void Init(ExecutableContext Context);

        /// <summary>
        /// Calls "Update" on all components attached to the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        public void Update(double timeSinceLastFrame);

        /// <summary>
        /// Calls "Draw" on all componets attached to the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Draw was called</param>
        public void Draw(double timeSinceLastFrame);

        /// <summary>
        /// Adds a component to the game entity
        /// </summary>
        /// <param name="component">the component to add</param>
        public void AddComponent(IComponent component);
    }
}
