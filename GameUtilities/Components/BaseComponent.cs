using GameUtilities.Entities;
using GameUtilities.Framework;
using GameUtilities.Framework.Loggers;
using System;

namespace GameUtilities.Components
{
    /// <summary>
    /// A base class all Components inherit from
    /// </summary>
    public class BaseComponent:IComponent
    {
        #region Fields
        /// <summary>
        /// The context
        /// </summary>
        protected ExecutableContext mContext = null;

        /// <summary>
        /// The component's Logger
        /// </summary>
        protected ILogger mLogger;

        /// <summary>
        /// The name of the Component
        /// </summary>
        protected String mName;

        /// <summary>
        /// The entity this Component is associated with
        /// </summary>
        protected IEntity mEntity;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseComponent() 
        {
            
        }
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
            mName = string.Format("{0}@{1}",this.GetType().Name,mContext.Entity.ToString());
            mLogger = LoggerFactory.CreateLogger(mName);
            mEntity = mContext.Entity;
        }
        #endregion IComponent Methods
    }
}
