namespace GameUtilities.Components.Constants.Camera
{
    /// <summary>
    /// Storage for various readonlyants used by Components
    /// </summary>
    public class ComponentConstants
    {
        /// <summary>
        /// The camera's X position
        /// </summary>
        public static readonly string CAMERA_POS_X = "CamPosX";

        /// <summary>
        /// The camera's Y position
        /// </summary>
        public static readonly string CAMERA_POS_Y = "CamPosY";

        /// <summary>
        /// The camera's Z position
        /// </summary>
        public static readonly string CAMERA_POS_Z = "CamPosZ";

        /// <summary>
        /// The camera target's X position
        /// </summary>
        public static readonly string CAMERA_TARGET_X = "CamTargetX";

        /// <summary>
        /// The camera target's Y position
        /// </summary>
        public static readonly string CAMERA_TARGET_Y = "CamTargetY";

        /// <summary>
        /// The camera target's Z position
        /// </summary>
        public static readonly string CAMERA_TARGET_Z = "CamTargetZ";

        /// <summary>
        /// The camera Up vector's X position
        /// </summary>
        public static readonly string CAMERA_UP_X = "CamUpX";

        /// <summary>
        /// The camera Up vector's Y position
        /// </summary>
        public static readonly string CAMERA_UP_Y = "CamUpY";

        /// <summary>
        /// The camera Up vector's Z position
        /// </summary>
        public static readonly string CAMERA_UP_Z = "CamUpZ";

        /// <summary>
        /// The camera's Near Plane
        /// </summary>
        public static readonly string CAMERA_ZNEAR = "CamNear";

        /// <summary>
        /// The camera's Far Plane
        /// </summary>
        public static readonly string CAMERA_ZFAR = "CamFar";

        /// <summary>
        /// The camera's type (ORTHOGRAPHIC|PERSPECTIVE)
        /// </summary>
        public static readonly string CAMERA_TYPE = "CamType";

        /// <summary>
        /// The supported camera types
        /// </summary>
        public enum CAM_TYPES { ORTHOGRAPHIC, PERSPECTIVE };

        /// <summary>
        /// The camera's Field Of View
        /// </summary>
        public static readonly string CAMERA_FOV = "CamFOV";

        /// <summary>
        /// The camera's aspect ratio
        /// </summary>
        public static readonly string CAMERA_ASPECT = "CamAspect";

        /// <summary>
        /// The camera's width
        /// </summary>
        public static readonly string CAMERA_WIDTH = "CamWidth";

        /// <summary>
        /// The camera's height
        /// </summary>
        public static readonly string CAMERA_HEIGHT = "CamHeight";
    }
}
