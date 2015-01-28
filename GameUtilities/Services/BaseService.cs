using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Services
{
    /// <summary>
    /// Base class for all Services
    /// </summary>
    public abstract class BaseService : IService
    {
        /// <summary>
        /// The service's Logger
        /// </summary>
        protected ILogger mLogger;

        /// <summary>
        /// The service's Executable Context
        /// </summary>
        protected IExecutableContext mContext;

        /// <summary>
        /// The Service's Name
        /// </summary>
        protected string mName;

        /// <summary>
        /// The constructor
        /// </summary>
        public BaseService()
        {
            mName = this.GetType().Name;
            mLogger = LoggerFactory.CreateLogger(mName);
        }

        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="context">the service's ExecutableContext</param>
        public virtual void Init(IExecutableContext context)
        {
            mLogger.Info(string.Format("Creating Service {0}",mName));
            mContext = context;
        }

        /// <summary>
        /// Called once a frame
        /// </summary>
        /// <param name="timeSinceLastFrame">How long it's been since the last frame</param>
        public void Update(double timeSinceLastFrame)
        {
            Dictionary<string, List<IMessage>> messages = mContext.MessageRouter.GetMessages(this);
            Update(timeSinceLastFrame, messages);
        }

        /// <summary>
        /// Overriden by child classes
        /// </summary>
        /// <param name="timeSinceLastFrame"></param>
        /// <param name="messages"></param>
        public abstract void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages);

        /// <summary>
        /// Terminate the Service
        /// </summary>
        public virtual void Terminate()
        {
            mLogger.Terminate();
        }

        /// <summary>
        /// Handle the message
        /// </summary>
        /// <param name="Topic"></param>
        /// <param name="message"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public virtual bool HandleMessage(string Topic, IMessage message, ref object returnValue)
        {
            //The only time this should be handled is if we got an unrecognized message, log it
            mLogger.Warn(string.Format("{0} got unrecognized message! MessageType: {1}", mName, message.GetType().Name));
            return false;
        }
    }
}
