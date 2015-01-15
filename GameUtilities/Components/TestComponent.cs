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
        /// <summary>
        /// Initialize the component
        /// </summary>
        /// <param name="Context">The context</param>
        /// <param name="data">entity data</param>
        public override void Init(IExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);
        }

        /// <summary>
        /// Update the component
        /// </summary>
        /// <param name="timeSinceLastFrame">How long since the last frame</param>
        public override void Update(double timeSinceLastFrame)
        {
            base.Update(timeSinceLastFrame);
        }

        /// <summary>
        /// Draw the square
        /// </summary>
        /// <param name="timeSinceLastFrame">How long since the last frame</param>
        public override void Draw(double timeSinceLastFrame)
        {
            base.Draw(timeSinceLastFrame);
        }
    }
}
