using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;

namespace GameUtilities.Services
{
    /// <summary>
    /// Base class for all Services
    /// </summary>
    public class BaseService : IService
    {
        /// <summary>
        /// The service's Logger
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// The service's Executable Context
        /// </summary>
        private IExecutableContext mContext;

        /// <summary>
        /// The Service's Name
        /// </summary>
        private string mName;

        /// <summary>
        /// The constructor
        /// </summary>
        public BaseService()
        {
            mName = this.GetType().ToString();
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
        public virtual void Update(double timeSinceLastFrame)
        {
            //Overriden by child classes
        }
    }
}
