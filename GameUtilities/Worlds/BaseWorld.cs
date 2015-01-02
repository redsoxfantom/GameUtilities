using System.Collections.Generic;
using GameUtilities.Framework.Loggers;
using GameUtilities.Framework;
using GameUtilities.Entities;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Worlds.DataContracts;
using System;

namespace GameUtilities.Worlds
{
    /// <summary>
    /// The base class of a World instance
    /// </summary>
    public class BaseWorld : IWorld
    {
        #region Fields
        /// <summary>
        /// A dictionary mapping entity Ids to entity objects
        /// </summary>
        private Dictionary<string, IEntity> EntityIdDictionary;

        /// <summary>
        /// A List of all entities in the world
        /// </summary>
        private List<IEntity> EntityList;

        /// <summary>
        /// The data used to define this World
        /// </summary>
        private WorldData mData;

        /// <summary>
        /// The world's logger
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// The executable context of the world. Passed to all Entities.
        /// </summary>
        private ExecutableContext mContext;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The constructor
        /// </summary>
        public BaseWorld(WorldData data)
        {
            EntityIdDictionary = new Dictionary<string, IEntity>();
            EntityList = new List<IEntity>();
            mData = data;
            mLogger = LoggerFactory.CreateLogger(mData.Name);

            mLogger.Info(string.Format("Created world '{0}'", mData.Name));
        }
        #endregion Constructors

        #region IWorld Methods
        /// <summary>
        /// Get an entity given its unique ID (The entities name)
        /// </summary>
        /// <param name="entityId">The ID of the entity</param>
        /// <returns>a reference to the Entity</returns>
        public IEntity GetEntity(string entityId)
        {
            IEntity foundEntity = null;
            if(EntityIdDictionary.TryGetValue(entityId,out foundEntity))
            {
                return foundEntity;
            }
            else
            {
                //TODO: should return a NullEntity instead? Ideally we should never ask the world for a bad entity ID
                return null;
            }
        }

        /// <summary>
        /// Initialize the World (Read in Entities and Components)
        /// </summary>
        public void Init(ExecutableContext context)
        {
            mLogger.Info(string.Format("Initializing world '{0}'", mData.Name));
            mContext = context;
            mContext.World = this;

            //The world is given a list of Entities in it, we need to parse through it and create Entity objects
            foreach(EntityData entityData in mData.Entities)
            {
                try
                {
                    mLogger.Info(string.Format("Creating Entity '{0}' of Type '{1}' and Assembly '{2}'", entityData.Name, entityData.Type, entityData.Assembly));

                    Type entityType = Type.GetType(entityData.Assembly);
                    Object[] objArray = { entityData };
                    IEntity entity = (IEntity)Activator.CreateInstance(entityType, objArray);
                    AddEntity(entity);

                    entity.Init(mContext);
                }
                catch(Exception e)
                {
                    mLogger.Error(string.Format("Failed to create entity '{0}'", entityData.Name), e);
                }
            }

            mLogger.Info(string.Format("Done initializing world '{0}'", mData.Name));
        }

        /// <summary>
        /// Call "Update" on all Entities
        /// </summary>
        /// <param name="timeSinceLastUpdate">Time since Update was called</param>
        public void Update(double timeSinceLastUpdate)
        {
            foreach(IEntity entity in EntityList)
            {
                entity.Update(timeSinceLastUpdate);
            }
        }

        /// <summary>
        /// Call "Draw" on all Entities
        /// </summary>
        /// <param name="timeSinceLastUpdate">Time since Draw was called</param>
        public void Draw(double timeSinceLastUpdate)
        {
            foreach(IEntity entity in EntityList)
            {
                entity.Draw(timeSinceLastUpdate);
            }
        }

        /// <summary>
        /// Shut down the World
        /// </summary>
        public void Terminate()
        {
            mLogger.Info(string.Format("World {0} starting termination...",mData.Name));
            foreach(IEntity entity in EntityList)
            {
                entity.Terminate();
            }
            mLogger.Info(string.Format("World {0} finished termination",mData.Name));
        }
        #endregion IWorld Methods

        #region Methods
        /// <summary>
        /// Add an entity to the Dictionary and List
        /// </summary>
        /// <param name="entity">the entity to add</param>
        private void AddEntity(IEntity entity)
        {
            EntityIdDictionary.Add(entity.Name, entity);
            EntityList.Add(entity);
        }

        /// <summary>
        /// Remove an entity from the World
        /// </summary>
        /// <param name="entity">the entity to remove</param>
        private void RemoveEntity(IEntity entity)
        {
            EntityIdDictionary.Remove(entity.Name);
            EntityList.Remove(entity);
        }
        #endregion Methods
    }
}
