using GameUtilities.Entities;
using GameUtilities.Framework;
using System;

namespace GameUtilities.Components
{
    /// <summary>
    /// A base class all Components inherit from
    /// </summary>
    class BaseComponent:IComponent
    {
        #region Fields
        /// <summary>
        /// The context
        /// </summary>
        private ExecutableContext mContext = null;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseComponent() {}
        #endregion Constructors

        #region IComponent Methods
        /// <summary>
        /// Called once a frame, draws the component
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        public void Draw(double timeSinceLastFrame) { }

        /// <summary>
        /// Called once a frame, updates the component's internal state
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        public void Update(double timeSinceLastFrame) { }

        /// <summary>
        /// Initialize the Component
        /// </summary>
        /// <param name="Context">The component's executable context</param>
        public void Init(ExecutableContext Context)
        {
            if(Context == null)
            {
                throw new NullReferenceException("Context");
            }
            mContext = Context;
        }
        #endregion IComponent Methods
    }
}
