﻿using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.InputHandlers;
using GameUtilities.Framework.Utilities.Message;
using OpenTK.Input;
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
        /// A dictionary mapping Keypresses to Topics that the Input service should publish
        /// the keypress message to
        /// </summary>
        private Dictionary<Key, string> KeyTopicDictionary;

        /// <summary>
        /// Reference to helper class that reads in input;
        /// </summary>
        private IInputHandler handler;

        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="context">The executable context</param>
        public override void Init(IExecutableContext context)
        {
            KeyTopicDictionary = new Dictionary<Key, string>();
            handler = new InputHandler();
            
            base.Init(context);
        }

        /// <summary>
        /// Handle all input events since last frame and convert them into generic input messages
        /// </summary>
        /// <param name="timeSinceLastFrame"></param>
        /// <param name="messages"></param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {
            HandleInput();
            
            object retObj = new object();

            foreach (string Topic in messages.Keys)
            {
                foreach (IMessage message in messages[Topic])
                {
                    HandleMessage(Topic, message, ref retObj);
                }
            }
        }

        /// <summary>
        /// Handle an individual message from the MessageRouter
        /// </summary>
        /// <param name="Topic">The topic this message was sent on</param>
        /// <param name="message">The message object</param>
        /// <param name="returnValue">An optional return value</param>
        /// <returns>Whether or not the message was handled</returns>
        public override bool HandleMessage(string Topic, IMessage message, ref object returnValue)
        {
            return base.HandleMessage(Topic, message, ref returnValue);
        }

        /// <summary>
        /// Terminate the InputService
        /// </summary>
        public override void Terminate()
        {
            KeyTopicDictionary.Clear();

            base.Terminate();
        }

        /// <summary>
        /// Handles all Keypresses by publishing the keys that are down to their topic
        /// </summary>
        /// <param name="keyboardState">The current state of the keyboard</param>
        private void HandleInput()
        {
            handler.GetInputs();

            //Loop through each Key in the dictionary
            foreach(Key key in KeyTopicDictionary.Keys)
            {
                //If that key was "down" (pressed)
                if(handler.isKeyDown(key))
                {
                    mLogger.Debug(string.Format("Key {0} was pressed, sending message to {1}", key.ToString(), KeyTopicDictionary[key]));
                    KeypressMessage msg = new KeypressMessage();
                    mContext.MessageRouter.SendMessage(KeyTopicDictionary[key], msg);
                }
            }
        }
    }
}
