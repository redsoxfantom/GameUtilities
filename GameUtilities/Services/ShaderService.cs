using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Services
{
    /// <summary>
    /// Service providing utilities for creating Shaders
    /// </summary>
    public class ShaderService : BaseService
    {
        /// <summary>
        /// Initialize the Service. Register for all needed Topics
        /// </summary>
        /// <param name="context">the services executable context</param>
        public override void Init(IExecutableContext context)
        {
            base.Init(context);
            mContext.MessageRouter.RegisterTopic(MessagingConstants.SHADER_SERVICE_TOPIC, this);
        }

        /// <summary>
        /// Update the Shader Service
        /// </summary>
        /// <param name="timeSinceLastFrame">Time since last frame</param>
        /// <param name="messages">Dictionary of messages</param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {
            object retObj = new object();

            foreach(string Topic in messages.Keys)
            {
                foreach(IMessage message in messages[Topic])
                {
                    HandleMessage(Topic, message, ref retObj);
                }
            }
        }

        /// <summary>
        /// Handle incoming messages
        /// </summary>
        /// <param name="Topic">Topic the message came from</param>
        /// <param name="message">The message object</param>
        /// <param name="returnValue">The returned object</param>
        /// <returns>Whether or not the call succeded</returns>
        public override bool HandleMessage(string Topic, IMessage message, ref object returnValue)
        {
            return base.HandleMessage(Topic, message, ref returnValue);
        }
    }
}
