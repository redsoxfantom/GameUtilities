using GameUtilities.Entities;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;

namespace GameUtilities.Worlds
{
    /// <summary>
    /// A null World class
    /// </summary>
    class NullWorld : IWorld
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="data">unused</param>
        public NullWorld(WorldData data)
        {
            //Do nothing
        }

        /// <summary>
        /// Get the entity from the world
        /// </summary>
        /// <param name="entityId">The entity ID to return</param>
        /// <returns>A nullentity</returns>
        public IEntity GetEntity(string entityId)
        {
            return new NullEntity(null);
        }

        /// <summary>
        /// Initialize the World
        /// </summary>
        /// <param name="context">unused</param>
        public void Init(IExecutableContext context)
        {
            //Do nothing
        }

        /// <summary>
        /// Update the world
        /// </summary>
        /// <param name="timeSinceLastFrame">unused</param>
        public void Update(double timeSinceLastFrame)
        {
            //Do nothing
        }

        /// <summary>
        /// Draw the World
        /// </summary>
        /// <param name="timeSinceLastFrame">unused</param>
        public void Draw(double timeSinceLastFrame)
        {
            //Do nothing
        }

        /// <summary>
        /// Terminate the world
        /// </summary>
        public void Terminate()
        {
            //Do nothing
        }

        /// <summary>
        /// Update the world
        /// </summary>
        /// <param name="message"></param>
        /// <param name="returnValue"></param>
        /// <returns>false</returns>
        public bool HandleMessage(Framework.Utilities.Message.IMessage message, ref object returnValue)
        {
            return false;
        }
    }
}
