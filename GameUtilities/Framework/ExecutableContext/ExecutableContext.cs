using GameUtilities.Entities;
using GameUtilities.Framework.Loggers;
using GameUtilities.Worlds;
using GameUtilities.Framework.FilePathResolver;

namespace GameUtilities.Framework.ExecutableContext
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
        public IFilePathResolver ConfigManager { set; get; }

        /// <summary>
        /// The constructor
        /// </summary>
        public BaseExecutableContext(string PathToConfig)
        {
            ConfigManager = new ConfigManager();
            ConfigManager.Init(PathToConfig);
        }
    }
}
