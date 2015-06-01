using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// Used to stop the task
        /// </summary>
        private CancellationTokenSource mCancelTokenSource;

        /// <summary>
        /// The executable context of the thread
        /// </summary>
        private IExecutableContext mContext;

        /// <summary>
        /// The logger for this thread
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// Represents the asynchronous task
        /// </summary>
        private Task mWorker;

        /// <summary>
        /// Constructor for the thread
        /// </summary>
        public BaseServiceThread()
        {
            lockObject = new object();
            mCancelTokenSource = new CancellationTokenSource();
            mWorker = new Task(new Action(ThreadFunction),mCancelTokenSource.Token);
        }

        /// <summary>
        /// Initialize the Thread
        /// </summary>
        /// <param name="context"></param>
        public virtual void Init(IExecutableContext context)
        {
            mContext = context;
            mLogger = LoggerFactory.CreateLogger(this.GetType().Name);
        }

        /// <summary>
        /// The method this service thread will execute.
        /// </summary>
        protected virtual void ThreadFunction()
        {
            //Overriden by child class
        }

        /// <summary>
        /// Starts up the thread. Does nothing if the thread is already running
        /// </summary>
        public void StartThread()
        {
            if(mWorker.Status != TaskStatus.Running)
            {
                mLogger.Debug(string.Format("Worker thread status is {0}, so starting",mWorker.Status));
                mWorker.Start();
            }
            else
            {
                mLogger.Warn("Attempted to start a worker thread that was already running!");
            }
        }

        /// <summary>
        /// Stops the running thread
        /// </summary>
        public void StopThread()
        {
            try
            {
                if (mWorker.Status == TaskStatus.Running)
                {
                    mLogger.Info("Attempting to cancel thread");
                    mCancelTokenSource.Cancel();
                }
                else
                {
                    mLogger.Info("Attempted to cancel a thread that was already done executing");
                }
            }
            catch(Exception e)
            {
                mLogger.Error("Error cancelling thread", e);
            }
        }
    }
}
