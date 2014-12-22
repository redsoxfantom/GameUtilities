using GameUtilities.Entities;

namespace GameUtilities.Components
{
    /// <summary>
    /// Represents a "Component" attached to an entity. Entitys are defined by what Components they use.
    /// </summary>
    interface IComponent
    {
        /// <summary>
        /// Called once a frame
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        public void Update(double timeSinceLastFrame);
    }
}
