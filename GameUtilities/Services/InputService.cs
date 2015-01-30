﻿using GameUtilities.Framework.Utilities.ExecutableContext;
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
        /// Initialize the Service
        /// </summary>
        /// <param name="context">The executable context</param>
        public override void Init(IExecutableContext context)
        {
            base.Init(context);
        }

        /// <summary>
        /// Handle all input events since last frame and convert them into generic input messages
        /// </summary>
        /// <param name="timeSinceLastFrame"></param>
        /// <param name="messages"></param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<Framework.Utilities.Message.IMessage>> messages)
        {
            throw new NotImplementedException();
        }
    }
}