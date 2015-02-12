namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// Constants to use for Message Topics
    /// </summary>
    public class MessagingConstants
    {
        /// <summary>
        /// Topic to subscribe to for receiving camera matrix updates
        /// </summary>
        public static string CAMERA_MATRIX_TOPIC = "PerspectiveViewMatrixUpdate";

        /// <summary>
        /// Topic to send requests to load a shader from source and create a Shader object
        /// </summary>
        public static string SHADER_SERVICE_TOPIC = "ShaderService";

        /// <summary>
        /// Topic to send requests to the currently active world object.
        /// The world object should register for this upon initialization
        /// </summary>
        public static string ACTIVE_WORLD = "ActiveWorld";

        /// <summary>
        /// Topic the Engine sends button presses to.
        /// Handled by the InputService
        /// </summary>
        public static string INPUT_SERVICE_TOPIC = "InputService";
    }
}
