using GameUtilities.Entities;
using GameUtilities.Framework;
using GameUtilities.Framework.Loggers;
using GameUtilities.Framework.DataContracts;
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

        /// <summary>
        /// The data passed in from the Entity
        /// </summary>
        private DataSet mDataSet;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseComponent() 
        { }
        #endregion Constructors

        #region IComponent Methods
        /// <summary>
        /// Called once a frame, draws the component
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        public virtual void Draw(double timeSinceLastFrame) { }

        /// <summary>
        /// Called once a frame, updates the component's internal state
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last frame</param>
        public virtual void Update(double timeSinceLastFrame) { }

        /// <summary>
        /// Shut down the component
        /// </summary>
        public virtual void Terminate()
        {
            mLogger.Info(string.Format("Component {0} terminating", mName));
        }

        /// <summary>
        /// Initialize the Component
        /// </summary>
        /// <param name="Context">The component's executable context</param>
        /// <param name="data">Optional data for the Component</param>
        public virtual void Init(ExecutableContext Context, DataSet data = null)
        {
            if(Context == null)
            {
                throw new NullReferenceException("Context");
            }
            if (data == null)
            {
                mDataSet = new DataSet();
            }
            else
            {
                mDataSet = data;                
            }
            mContext = Context;
            mName = string.Format("{0}@{1}",this.GetType().Name,mContext.Entity.Name);
            mLogger = LoggerFactory.CreateLogger(mName);
            mEntity = mContext.Entity;
        }
        #endregion IComponent Methods
    }
}
