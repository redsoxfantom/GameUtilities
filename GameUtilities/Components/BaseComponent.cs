using GameUtilities.Entities;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Framework.DataContracts;
using System;
using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Components
{
    /// <summary>
    /// A base class all Components inherit from
    /// </summary>
    public abstract class BaseComponent:IComponent
    {
        #region Fields
        /// <summary>
        /// The context
        /// </summary>
        protected IExecutableContext mContext = null;

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

        /// <summary>
        /// The name of the Component
        /// </summary>
        public string Name
        {
            get { return mName; }
        }
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
        public void Update(double timeSinceLastFrame) 
        {
            Dictionary<string, List<IMessage>> messages = mContext.MessageRouter.GetMessages(this);
            Update(timeSinceLastFrame, messages);
        }

        /// <summary>
        /// Update with messages
        /// </summary>
        /// <param name="timeSinceLastFrame">How long since last frame</param>
        /// <param name="messages">Messages received</param>
        protected abstract void Update(double timeSinceLastFrame, Dictionary<string,List<IMessage>> messages);

        /// <summary>
        /// Shut down the component
        /// </summary>
        public virtual void Terminate()
        {
            mLogger.Info(string.Format("Component {0} terminating", mName));
            mLogger.Terminate();
        }

        /// <summary>
        /// Initialize the Component
        /// </summary>
        /// <param name="Context">The component's executable context</param>
        /// <param name="data">Optional data for the Component</param>
        public virtual void Init(IExecutableContext Context, DataSet data = null)
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
            mContext.MessageRouter.RegisterTopic(mName, this);
        }

        /// <summary>
        /// Handle a direct message from the message router
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="returnValue">the return value</param>
        /// <returns>Always returns false, should be overriden</returns>
        public virtual bool HandleMessage(String Topic, IMessage message, ref object returnValue)
        {
            return false;
        }

        #endregion IComponent Methods
    }
}
