using GameUtilities.Components;
using GameUtilities.Framework;
using System.Collections.Generic;
using GameUtilities.Framework.Loggers;
using System;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Base class for all game Entities
    /// </summary>
    public class BaseEntity : IEntity
    {
        #region Fields
        /// <summary>
        /// The entities' executable context
        /// </summary>
        protected ExecutableContext mContext;

        /// <summary>
        /// Stores the entites Components, in no particular order
        /// </summary>
        protected List<IComponent> mComponents;

        /// <summary>
        /// The "Name" of the entity (used for logging)
        /// </summary>
        protected string mName;

        /// <summary>
        /// The Entities' logger
        /// </summary>
        public ILogger Logger {get; private set;}

        public string Name
        {
            get
            {
                return mName;
            }
        }
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The Constructor
        /// </summary>
        public BaseEntity(string Name)
        {
            mName = string.Format("{0}.{1}",Name,Guid.NewGuid());
            mComponents = new List<IComponent>();
        }
        #endregion Contructors

        #region IEntity Methods
        /// <summary>
        /// Initialize the Entity
        /// </summary>
        /// <param name="Context">The executable context of the entity</param>
        public void Init(Framework.ExecutableContext Context)
        {
            mContext = Context;
            Logger = LoggerFactory.CreateLogger(mName);
            mContext.Logger.AddChildLogger(Logger);
            //Read in the entities components here
        }

        /// <summary>
        /// Call Update on all Entity components
        /// </summary>
        /// <param name="timeSinceLastFrame">time since Update was last called</param>
        public void Update(double timeSinceLastFrame)
        {
            foreach(IComponent component in mComponents)
            {
                component.Update(timeSinceLastFrame);
            }
        }

        /// <summary>
        /// Call Draw on all Entity components
        /// </summary>
        /// <param name="timeSinceLastFrame">time since Draw was last called</param>
        public void Draw(double timeSinceLastFrame)
        {
            foreach(IComponent component in mComponents)
            {
                component.Update(timeSinceLastFrame);
            }
        }

        #endregion IEntity Methods

        #region Methods
        /// <summary>
        /// toString method
        /// </summary>
        /// <returns>the entity's name</returns>
        public override String ToString()
        {
            return mName;
        }
        #endregion Methods
    }
}
