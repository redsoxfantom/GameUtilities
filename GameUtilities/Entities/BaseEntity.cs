﻿using GameUtilities.Components;
using GameUtilities.Framework;
using System.Collections.Generic;
using GameUtilities.Framework.Loggers;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Framework.DataContracts;
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
        /// The data the Entity was created with
        /// </summary>
        private EntityData mData;

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
        public BaseEntity(EntityData data)
        {
            mComponents = new List<IComponent>();
            mData = data;
            if(string.IsNullOrEmpty(data.Name))
            {
                mName = data.Type;
            }
            else
            {
                mName = data.Name;
            }
            mName += string.Format(".{0}", Guid.NewGuid());
            Logger = LoggerFactory.CreateLogger(mName);

            Logger.Info(string.Format("Created Entity '{0}'", mName));
        }
        #endregion Contructors

        #region IEntity Methods
        /// <summary>
        /// Initialize the Entity
        /// </summary>
        /// <param name="Context">The executable context of the entity</param>
        public void Init(ExecutableContext Context)
        {
            Logger.Info(string.Format("Initializing Entity '{0}'",mName));
            mContext = Context;
            mContext.Entity = this;

            //Read in the entities components here
            string path = Context.ConfigManager.FindEntityType(mData.Type);
            EntityTypeData typeData = DataContractFactory.DeserializeObject<EntityTypeData>(path);

            foreach (string entry in typeData.Components)
            {
                try
                {
                    Logger.Info(string.Format("Creating component '{0}' for entity '{1}'",entry,mName));
                    Type componentType = Type.GetType(entry);
                    Object[] objArray = {mData.DataSet};
                    IComponent component = (IComponent)Activator.CreateInstance(componentType, objArray);
                    mComponents.Add(component);
                }
                catch (Exception e)
                {
                    Logger.Error(string.Format("Failed to create component '{0}' for entity '{1}", entry, mName),e);
                }
            }

            Logger.Info(string.Format("Finished Initializing Entity '{0}'", mName));
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
                component.Draw(timeSinceLastFrame);
            }
        }

        /// <summary>
        /// Shut down the entity
        /// </summary>
        public void Terminate()
        {
            Logger.Info(string.Format("Entity {0} starting termination...", mName));
            foreach(IComponent component in mComponents)
            {
                component.Terminate();
            }
            Logger.Info(string.Format("Entity {0} done termination", mName));
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
