using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using OpenTK;
using GameUtilities.Components.Constants.Camera;
using System;
using GameUtilities.Framework.Utilities.Message;
using System.Collections.Generic;

namespace GameUtilities.Components
{
    /// <summary>
    /// A Camera. When this component is attached to an Entity, the game considers that Entity to be the Camera into the world
    /// </summary>
    public class CameraComponent : BaseComponent
    {
        /// <summary>
        /// The camera's Position vector
        /// </summary>
        private Vector3d Pos;

        /// <summary>
        /// The Camera's target vector
        /// </summary>
        private Vector3d Target;

        /// <summary>
        /// The Camera's Up vector
        /// </summary>
        private Vector3d Up;

        /// <summary>
        /// The camera's near plane
        /// </summary>
        private double zNear;

        /// <summary>
        /// The camera's far plane
        /// </summary>
        private double zFar;

        /// <summary>
        /// The camera's field of view
        /// Only used for Perspective cameras
        /// </summary>
        private double cameraFOV;

        /// <summary>
        /// The camera's aspect ratio
        /// Only used for Perspective cameras
        /// </summary>
        private double cameraAspect;

        /// <summary>
        /// The camera's width
        /// Only used for Ortho cameras
        /// </summary>
        private double cameraWidth;

        /// <summary>
        /// The camera's height
        /// Only used for Perspective cameras
        /// </summary>
        private double cameraHeight;

        /// <summary>
        /// The camera's type
        /// </summary>
        private  ComponentConstants.CAM_TYPES cameraType;

        /// <summary>
        /// Determines if this component is "dirty" (needs to be updated)
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// The generated ViewPerspective matrix for this camera
        /// </summary>
        private Matrix4d viewPerspectiveMatrix;


#region IComponentMethods
        /// <summary>
        /// Initialize the Camera. Needs the following from the Dataset:
        /// CamPosX - The camera's X position
        /// CamPosY - The camera's Y position
        /// CamPosZ - The camera's Z position
        /// CamTargetX - The camera target's X position
        /// CamTargetY - The camera target's Y position
        /// CamTargetZ - The camera target's Z position
        /// CamUpX - The camera up vector's X component
        /// CamUpY - The camera up vector's Y component
        /// CamUpZ - The camera up vector's Z component
        /// CamNear - the Z value of the Near Plane
        /// CamFar - the Z value of the FarPlane
        /// CamType - {PERSPECTIVE | ORTHOGRAPHIC}
        /// If CameraType = PERSPECTIVE
        ///     CamFOV - The field of view of the camera
        ///     CamAspect - The aspect ratio of the camera
        /// If CameraType = ORTHOGRAHIC
        ///     CamWidth - The width of the camera field
        ///     CamHeight - the Height of the camera field
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="data"></param>
        public override void Init(IExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);

            //Get the Position 
            Pos.X = double.Parse(data[ComponentConstants.CAMERA_POS_X]);
            Pos.Y = double.Parse(data[ComponentConstants.CAMERA_POS_Y]);
            Pos.Z = double.Parse(data[ComponentConstants.CAMERA_POS_Z]);

            //Get the Target vector
            Target.X = double.Parse(data[ComponentConstants.CAMERA_TARGET_X]);
            Target.Z = double.Parse(data[ComponentConstants.CAMERA_TARGET_Z]);
            Target.Y = double.Parse(data[ComponentConstants.CAMERA_TARGET_Y]);

            //Get the Up vector
            Up.X = double.Parse(data[ComponentConstants.CAMERA_UP_X]);
            Up.Y = double.Parse(data[ComponentConstants.CAMERA_UP_Y]);
            Up.Z = double.Parse(data[ComponentConstants.CAMERA_UP_Z]);

            //Get the near and far planes
            zNear = double.Parse(data[ComponentConstants.CAMERA_ZNEAR]);
            zFar = double.Parse(data[ComponentConstants.CAMERA_ZFAR]);

            //determine the type of camera the user selected
            cameraType = (ComponentConstants.CAM_TYPES)Enum.Parse(typeof(ComponentConstants.CAM_TYPES), data[ComponentConstants.CAMERA_TYPE]);
            if (cameraType == ComponentConstants.CAM_TYPES.ORTHOGRAPHIC)
            {
                cameraWidth = double.Parse(data[ComponentConstants.CAMERA_WIDTH]);
                cameraHeight = double.Parse(data[ComponentConstants.CAMERA_HEIGHT]);
            }
            else
            {
                cameraFOV = double.Parse(data[ComponentConstants.CAMERA_FOV]);
                cameraAspect = double.Parse(data[ComponentConstants.CAMERA_ASPECT]);
            }

            viewPerspectiveMatrix = generateMatrix(Pos, Up, Target, cameraType, zNear, zFar, cameraWidth, cameraHeight,cameraAspect,cameraFOV);
            isDirty = false;
        }

        /// <summary>
        /// Moves the Camera if necessary
        /// </summary>
        /// <param name="timeSinceLastFrame">How long it's been since the last frame</param>
        protected override void Update(double timeSinceLastFrame, Dictionary<string,List<IMessage>> messages)
        {
            if(isDirty)
            {
                viewPerspectiveMatrix = generateMatrix(Pos, Up, Target, cameraType, zNear, zFar, cameraWidth, cameraHeight, cameraAspect, cameraFOV);
                isDirty = false;
            }

            CameraMatrixMessage msg = new CameraMatrixMessage();
            msg.Init(viewPerspectiveMatrix);
            mContext.MessageRouter.SendMessage(MessagingConstants.CAMERA_MATRIX_TOPIC, msg);
        }
#endregion IComponentMethods

#region Private Methods
        /// <summary>
        /// Generates a 4x4 double Matrix representing the camera's View (with Perspective added)
        /// </summary>
        /// <param name="Pos">The camera's Position</param>
        /// <param name="Up">The camera's Up vector</param>
        /// <param name="Target">The camera's Target vector</param>
        /// <param name="cameraType">The camera's Type</param>
        /// <param name="zFar">The camera's ZFar</param>
        /// <param name="zNear">The camera's zNear</param>
        /// <param name="cameraWidth">The camera's width</param>
        /// <param name="cameraHeight">The camera's height</param>
        /// <param name="cameraAspect">The camera's aspect ratio</param>
        /// <param name="cameraFOV">The camera's field of view</param>
        /// <returns>a 4x4 double Matrix</returns>
        private Matrix4d generateMatrix(Vector3d Pos, Vector3d Up, Vector3d Target, ComponentConstants.CAM_TYPES cameraType, double zNear, double zFar, double cameraWidth = 0, double cameraHeight = 0, double cameraAspect = 0, double cameraFOV = 0)
        {
            Matrix4d ProjectionMatrix;
            if(cameraType == ComponentConstants.CAM_TYPES.ORTHOGRAPHIC)
            {
                ProjectionMatrix = Matrix4d.CreateOrthographic(cameraWidth, cameraHeight, zNear, zFar);
            }
            else
            {
                ProjectionMatrix = Matrix4d.CreatePerspectiveFieldOfView(cameraFOV, cameraAspect, zNear, zFar);
            }

            Matrix4d ViewMatrix = Matrix4d.LookAt(Pos, Target, Up);

            Matrix4d ResultMatrix = ProjectionMatrix * ViewMatrix;

            return ResultMatrix;
        }
#endregion Private Methods
    }
}
