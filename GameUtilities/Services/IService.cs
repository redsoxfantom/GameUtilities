using GameUtilities.Framework;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message;

namespace GameUtilities.Services
{
    /// <summary>
    /// Base interface for a Service
    /// </summary>
    public interface IService : IUpdatable, ITerminatable, IMessageDestination
    {
        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="context"></param>
        void Init(IExecutableContext context);
    }
}
