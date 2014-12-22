using GameUtilities.Entities;

namespace GameUtilities.Components
{
    /// <summary>
    /// A base class all Components inherit from
    /// </summary>
    class BaseComponent:IComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entity">entity this component is associated with</param>
        public BaseComponent(IEntity entity)
        {

        }

        /// <summary>
        /// Called once a frame
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since last frame</param>
        void Update(double timeSinceLastFrame)
        {
            //Overridden by child classes
        }
    }
}
