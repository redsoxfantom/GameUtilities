using GameUtilities.Framework;

namespace GameUtilities.Framework.Engine
{
    /// <summary>
    /// Interface between the Engine and the outside world. Responsible for initializing the Engine
    /// and updating it every frame.
    /// </summary>
    public interface IEngine : IUpdatable, IDrawable, ITerminatable
    {
        /// <summary>
        /// Initialize the Engine. Creates the World and all the Services
        /// </summary>
        /// <param name="path">Path to the Config directory</param>
        /// <param name="world">The world to initialize. Comes from command arguments</param>
        void Init(string path, string world);
    }
}
