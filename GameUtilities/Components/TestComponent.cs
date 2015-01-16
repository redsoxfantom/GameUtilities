using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Components.Constants;
using OpenTK;
using System.Collections.Generic;
using GameUtilities.Framework.Utilities.Message;
using System;

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
        /// The mvpMatrix to use when drawing this component
        /// </summary>
        private Matrix4d mvpMatrix;

        /// <summary>
        /// Initialize the component
        /// </summary>
        /// <param name="Context">The context</param>
        /// <param name="data">entity data</param>
        public override void Init(IExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);
            Pos = new Vector3d();
            mvpMatrix = Matrix4d.Identity;

            Pos.X = double.Parse(data[BaseConstants.POS_X]);
            Pos.Y = double.Parse(data[BaseConstants.POS_Y]);
            Pos.Z = double.Parse(data[BaseConstants.POS_Z]);

            mContext.MessageRouter.RegisterTopic(MessagingConstants.CAMERA_MATRIX_TOPIC, this);
        }

        /// <summary>
        /// Update the component
        /// </summary>
        /// <param name="timeSinceLastFrame">How long since the last frame</param>
        protected override void Update(double timeSinceLastFrame, Dictionary<string,List<IMessage>> messages)
        {
            object ret = new object();

            foreach(string topic in messages.Keys)
            {
                foreach(IMessage message in messages[topic])
                {
                    HandleMessage(message, ref ret);
                }
            }
        }

        /// <summary>
        /// Draw the square
        /// </summary>
        /// <param name="timeSinceLastFrame">How long since the last frame</param>
        public override void Draw(double timeSinceLastFrame)
        {

        }

        /// <summary>
        /// Terminate the TestComponent
        /// </summary>
        public override void Terminate()
        {
            mContext.MessageRouter.DeregisterTopic(MessagingConstants.CAMERA_MATRIX_TOPIC, this);
            base.Terminate();
        }

        /// <summary>
        /// Handle messages for the 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public override bool HandleMessage(IMessage message, ref object returnValue)
        {
            Type messageType = message.GetType();

            //Got a CameraMatrixMessage, update the local mvpMatrix
            if(messageType == typeof(CameraMatrixMessage))
            {
                Matrix4d vpMatrix = (Matrix4d)message.GetData();
                mvpMatrix = Matrix4d.CreateTranslation(Pos) * vpMatrix;
                mLogger.Debug("TestComponent got updated camera message");
                return true;
            }

            return false;
        }
    }
}
