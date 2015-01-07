using GameUtilities.Framework;
using GameUtilities.Framework.Utilities.ExecutableContext;

namespace GameUtilities.Services
{
    /// <summary>
    /// Base interface for a Service
    /// </summary>
    public interface IService : IUpdatable
    {
        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="context"></param>
        void Init(IExecutableContext context);
    }
}
