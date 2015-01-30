using GameUtilities.Entities;
using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Worlds;
using GameUtilities.Framework.Utilities.FilePathResolver;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;

namespace GameUtilities.Framework.Utilities.ExecutableContext
{
    /// <summary>
    /// Stores entity-level information
    /// </summary>
    public class BaseExecutableContext : IExecutableContext
    {
        /// <summary>
        /// The root World
        /// </summary>
        public IWorld World { set; get; }

        /// <summary>
        /// The Entity the context is associated with
        /// </summary>
        public IEntity Entity { set; get; }

        /// <summary>
        /// The File Path resolver object
        /// </summary>
        public IFilePathResolver ConfigManager { private set; get; }

        /// <summary>
        /// The message router
        /// </summary>
        public IMessageRouter MessageRouter { private set; get; }

        /// <summary>
        /// The constructor
        /// </summary>
        public BaseExecutableContext(string PathToConfig)
        {
            ConfigManager = new ConfigManager();
            ConfigManager.Init(PathToConfig);

            MessageRouter = new MessageRouter();

            World = new NullWorld(null);
            Entity = new NullEntity(null);
        }
    }
}
