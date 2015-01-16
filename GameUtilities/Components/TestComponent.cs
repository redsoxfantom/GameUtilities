using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Components.Constants;
using OpenTK;
using System.Collections.Generic;
using GameUtilities.Framework.Utilities.Message;

namespace GameUtilities.Components
{
    /// <summary>
    /// Simple component for testing purposes
    /// </summary>
    public class TestComponent : BaseComponent
    {
        /// <summary>
        /// The test component's position
        /// </summary>
        private Vector3d Pos;

        /// <summary>
        /// Initialize the component
        /// </summary>
        /// <param name="Context">The context</param>
        /// <param name="data">entity data</param>
        public override void Init(IExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);
            Pos = new Vector3d();

            Pos.X = double.Parse(data[BaseConstants.POS_X]);
            Pos.Y = double.Parse(data[BaseConstants.POS_Y]);
            Pos.Z = double.Parse(data[BaseConstants.POS_Z]);
        }

        /// <summary>
        /// Update the component
        /// </summary>
        /// <param name="timeSinceLastFrame">How long since the last frame</param>
        protected override void Update(double timeSinceLastFrame, Dictionary<string,List<IMessage>> messages)
        {

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
