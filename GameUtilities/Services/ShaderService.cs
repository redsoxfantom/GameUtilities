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
        /// Update the Shader Service
        /// </summary>
        /// <param name="timeSinceLastFrame">Time since last frame</param>
        /// <param name="messages">Dictionary of messages</param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {
            throw new System.NotImplementedException();
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
            return false;
        }
    }
}
