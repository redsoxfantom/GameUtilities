using GameUtilities.Entities;
using GameUtilities.Framework.Utilities.Loggers;
using GameUtilities.Worlds;
using GameUtilities.Framework.Utilities.FilePathResolver;

namespace GameUtilities.Framework.Utilities.ExecutableContext
{
    /// <summary>
    /// Interface for the ExecutableContext object
    /// </summary>
    public interface IExecutableContext
    {
        /// <summary>
        /// The root World
        /// </summary>
        IWorld World { set; get; }

        /// <summary>
        /// The Entity the context is associated with
        /// </summary>
        IEntity Entity { set; get; }

        /// <summary>
        /// The File Path resolver object
        /// </summary>
        IFilePathResolver ConfigManager { set; get; }
    }
}
