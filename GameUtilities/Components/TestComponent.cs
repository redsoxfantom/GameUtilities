using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using OpenTK;

namespace GameUtilities.Components
{
    /// <summary>
    /// Simple component for testing purposes
    /// </summary>
    public class TestComponent : BaseComponent
    {
        public override void Init(IExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);
        }
    }
}
