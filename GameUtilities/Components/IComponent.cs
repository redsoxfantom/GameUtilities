using GameUtilities.Entities;
using GameUtilities.Framework;
using GameUtilities.Framework.ExecutableContext;
using GameUtilities.Framework.DataContracts;

namespace GameUtilities.Components
{
    /// <summary>
    /// Represents a "Component" attached to an entity. Entitys are defined by what Components they use.
    /// </summary>
    public interface IComponent : IUpdatable, IDrawable, ITerminatable
    {
        /// <summary>
        /// Initialize the Component
        /// </summary>
        /// <param name="Context">The component's executable context</param>
        /// <param name="data">Optional data for the Component</param>
        void Init(IExecutableContext Context, DataSet data = null);
    }
}
