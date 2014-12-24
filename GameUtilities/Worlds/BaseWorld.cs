using System.Collections.Generic;
using GameUtilities.Framework.Loggers;
using GameUtilities.Entities;

namespace GameUtilities.Worlds
{
    /// <summary>
    /// The base class of a World instance
    /// </summary>
    class BaseWorld : IWorld
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
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The constructor
        /// </summary>
        public BaseWorld()
        {
            EntityIdDictionary = new Dictionary<string, IEntity>();
            EntityList = new List<IEntity>();
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
        public void Init()
        {
            //Read in from filesystem here
            //Create all entites associated with the World, and call them to create their Components
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
