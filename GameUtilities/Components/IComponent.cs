using GameUtilities.Entities;
using GameUtilities.Framework;

namespace GameUtilities.Components
{
    /// <summary>
    /// Represents a "Component" attached to an entity. Entitys are defined by what Components they use.
    /// </summary>
    interface IComponent
    {
        /// <summary>
        /// Called once a frame, draws the component
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        void Draw(double timeSinceLastFrame);

        /// <summary>
        /// Called once a frame, updates the component's internal state
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        void Update(double timeSinceLastFrame);

        /// <summary>
        /// Initialize the Component
        /// </summary>
        /// <param name="Context">The component's executable context</param>
        void Init(ExecutableContext Context);
    }
}
