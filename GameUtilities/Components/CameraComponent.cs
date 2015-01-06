using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework;
using OpenTK;
using GameUtilities.Components.Camera;
using Constants = GameUtilities.Components.Camera.ComponentConstants;
using System;

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
        private double cameraheight;

        /// <summary>
        /// The camera's type
        /// </summary>
        private Constants.CAM_TYPES cameraType;

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
        public override void Init(ExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);

            //Get the Position 
            Pos.X = double.Parse(data[Constants.CAMERA_POS_X]);
            Pos.Y = double.Parse(data[Constants.CAMERA_POS_Y]);
            Pos.Z = double.Parse(data[Constants.CAMERA_POS_Z]);

            //Get the Target vector
            Target.X = double.Parse(data[Constants.CAMERA_TARGET_X]);
            Target.Z = double.Parse(data[Constants.CAMERA_TARGET_Z]);
            Target.Y = double.Parse(data[Constants.CAMERA_TARGET_Y]);

            //Get the Up vector
            Up.X = double.Parse(data[Constants.CAMERA_UP_X]);
            Up.Y = double.Parse(data[Constants.CAMERA_UP_Y]);
            Up.Z = double.Parse(data[Constants.CAMERA_UP_Z]);

            //Get the near and far planes
            zNear = double.Parse(data[Constants.CAM_ZNEAR]);
            zFar = double.Parse(data[Constants.CAM_ZFAR]);

            //determine the type of camera the user selected
            cameraType = (Constants.CAM_TYPES)Enum.Parse(typeof(Constants.CAM_TYPES), data[Constants.CAM_TYPE]);
            if(cameraType == Constants.CAM_TYPES.ORTHOGRAPHIC)
            {
                cameraWidth = double.Parse(data[Constants.CAM_WIDTH]);
                cameraheight = double.Parse(data[Constants.CAM_HEIGHT]);
            }
            else
            {
                cameraFOV = double.Parse(data[Constants.CAM_FOV]);
                cameraAspect = double.Parse(data[Constants.CAM_ASPECT]);
            }
        }
    }
}
