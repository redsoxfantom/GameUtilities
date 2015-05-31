using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameUtilities.Services;
using GameUtilities.Framework.Utilities.Message;

namespace GameUtilities.Services.ThreadedService
{
    /// <summary>
    /// Base class for Services that will spawn a thread to do work
    /// </summary>
    public class BaseThreadedService : BaseService
    {
        /// <summary>
        /// Worker thread for this class
        /// </summary>
        protected BaseServiceThread mThread;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseThreadedService()
        {
            mThread = new BaseServiceThread();
        }

        /// <summary>
        /// Handle messages sent since last frame
        /// </summary>
        /// <param name="timeSinceLastFrame">How much time has elapsed since last frame</param>
        /// <param name="messages">Messages received</param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {
            object retObj = new object();

            foreach (string Topic in messages.Keys)
            {
                foreach (IMessage message in messages[Topic])
                {
                    HandleMessage(Topic, message, ref retObj);
                }
            }
        }
    }
}
