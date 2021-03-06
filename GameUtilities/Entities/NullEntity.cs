﻿using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message;
using System;

namespace GameUtilities.Entities
{
    /// <summary>
    /// A null entity object
    /// </summary>
    public class NullEntity : IEntity
    {
        /// <summary>
        /// The null entities' logger
        /// </summary>
        public ILogger mLogger 
        {
            get { return new NullLogger("NULL"); }
        }

        /// <summary>
        /// The name of the null entity
        /// </summary>
        public string Name
        {
            get
            {
                return "NULL";
            }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="data">unused</param>
        public NullEntity(EntityData data)
        {

        }

        /// <summary>
        /// Initialize the null entity
        /// </summary>
        /// <param name="Context">unused</param>
        public void Init(IExecutableContext Context)
        {

        }

        /// <summary>
        /// Draw the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">unused</param>
        public void Draw(double timeSinceLastFrame)
        {

        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="timeSinceLastFrame">unused</param>
        public void Update(double timeSinceLastFrame)
        {

        }

        /// <summary>
        /// Terminate the entity
        /// </summary>
        public void Terminate()
        {

        }

        /// <summary>
        /// Handle the message
        /// </summary>
        /// <param name="Topic"></param>
        /// <param name="message"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public bool HandleMessage(String Topic, IMessage message, ref object returnValue)
        {
            return false;
        }
    }
}
