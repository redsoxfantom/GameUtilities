using GameUtilities.Framework.DataContracts;
using GameUtilities.Framework;
using OpenTK;
using Constants = GameUtilities.Components.ComponentConstants;

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
        private Vector3d Pos = new Vector3d(0.0,0.0,0.0);

        /// <summary>
        /// The Camera's target vector
        /// </summary>
        private Vector3d Target = new Vector3d(0.0, 0.0, -1.0);

        /// <summary>
        /// The Camera's Up vector
        /// </summary>
        private Vector3d Up = new Vector3d(0.0, 1.0, 0.0);

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
        private double CameraFOV;

        /// <summary>
        /// The camera's aspect ratio
        /// Only used for Perspective cameras
        /// </summary>
        private double CameraAspect;

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
        /// CameraNear - the Z value of the Near Plane
        /// CameraFar - the Z value of the FarPlane
        /// CameraType - {PERSPECTIVE | ORTHOGRAPHIC}
        /// If CameraType = PERSPECTIVE
        ///     CameraFOV - The field of view of the camera
        ///     CameraAspect - The aspect ratio of the camera
        /// If CameraType = ORTHOGRAHIC
        ///     CameraWidth - The width of the camera field
        ///     Cameraheight - the Height of the camera field
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="data"></param>
        public override void Init(ExecutableContext Context, DataSet data = null)
        {
            base.Init(Context, data);

            //Pos will have a value (0,0,0) if the dataset does not define a value for it
            double.TryParse(data[Constants.CAMERA_POS_X],out Pos.X);
            double.TryParse(data[Constants.CAMERA_POS_Y],out Pos.Y);
            double.TryParse(data[Constants.CAMERA_POS_Z],out Pos.Z);

            //Target will have a value (0,0,-1) if the dataset does not define a value for it
            double.TryParse(data[Constants.CAMERA_TARGET_X], out Target.X);
            double.TryParse(data[Constants.CAMERA_TARGET_Y], out Target.Y);
            double.TryParse(data[Constants.CAMERA_TARGET_Z], out Target.Z);

            //Up will have a value (0,1,0) if the dataset does not define a value for it
            double.TryParse(data[Constants.CAMERA_UP_X], out Up.X);
            double.TryParse(data[Constants.CAMERA_UP_Y], out Up.Y);
            double.TryParse(data[Constants.CAMERA_UP_Z], out Up.Z);
        }
    }
}
