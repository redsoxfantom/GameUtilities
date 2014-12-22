using GameUtilities.Components;
using GameUtilities.Framework;
using System.Collections.Generic;

namespace GameUtilities.Entities
{
    /// <summary>
    /// Base class for all game Entities
    /// </summary>
    class BaseEntity : IEntity
    {
        #region Fields
        /// <summary>
        /// The entities' executable context
        /// </summary>
        private ExecutableContext mContext;

        /// <summary>
        /// Stores the entites Components, in no particular order
        /// </summary>
        private List<IComponent> mComponents;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The Constructor
        /// </summary>
        public BaseEntity()
        {
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
            //Read in the entites components here
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
    }
}
