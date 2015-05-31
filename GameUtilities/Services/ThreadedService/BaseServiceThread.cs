using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Services.ThreadedService
{
    /// <summary>
    /// Base class for all threads that will run from a service
    /// </summary>
    public class BaseServiceThread
    {
        /// <summary>
        /// Object used as a lock to allow the owning service to safely shut down the thread
        /// </summary>
        private object lockObject;

        /// <summary>
        /// Boolean used to determine if the thread should run
        /// </summary>
        private bool isRunning;

        /// <summary>
        /// The executable context of the thread
        /// </summary>
        private IExecutableContext mContext;

        /// <summary>
        /// The logger for this thread
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// Constructor for the thread
        /// </summary>
        public BaseServiceThread()
        {
            lockObject = new object();
            isRunning = false;
        }

        /// <summary>
        /// Initialize the Thread
        /// </summary>
        /// <param name="context"></param>
        public void Init(IExecutableContext context)
        {
            mContext = context;
            LoggerFactory.CreateLogger(this.GetType().Name);
        }
    }
}
