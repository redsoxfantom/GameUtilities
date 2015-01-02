using GameUtilities.Entities;
using GameUtilities.Framework;
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
        void Init(ExecutableContext Context);
    }
}
