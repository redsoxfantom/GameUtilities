using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Services
{
    /// <summary>
    /// Service that handles Input from the User. Currently supports one Keyboard
    /// </summary>
    public class InputService : BaseService
    {
        /// <summary>
        /// The executable context used by this service
        /// </summary>
        private IExecutableContext mContext;

        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="context">The executable context</param>
        public override void Init(IExecutableContext context)
        {
            mContext = context;
            mContext.MessageRouter.RegisterTopic(MessagingConstants.INPUT_SERVICE_TOPIC, this);
            base.Init(context);
        }

        /// <summary>
        /// Handle all input events since last frame and convert them into generic input messages
        /// </summary>
        /// <param name="timeSinceLastFrame"></param>
        /// <param name="messages"></param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {

        }

        public override void Terminate()
        {
            mContext.MessageRouter.DeregisterTopic(MessagingConstants.INPUT_SERVICE_TOPIC, this);
            base.Terminate();
        }
    }
}
