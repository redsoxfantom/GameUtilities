using GameUtilities.Components;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Represents an object in the game world
    /// </summary>
    interface IEntity
    {
        /// <summary>
        /// Initializes the entity
        /// </summary>
        public void Init();

        /// <summary>
        /// Calls "Update" on all components attached to the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        public void Update(double timeSinceLastFrame);

        /// <summary>
        /// Adds a component to the game entity
        /// </summary>
        /// <param name="component">the component to add</param>
        public void AddComponent(IComponent component);
    }
}
