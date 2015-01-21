using OpenTK;

namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// Message for updates to the Camera Matrix
    /// </summary>
    public class CameraMatrixMessage : BaseMessage {}

    /// <summary>
    /// Message to signal the ShaderService to load a Shader from a file
    /// </summary>
    public class LoadShaderMessage : BaseMessage {}

    /// <summary>
    /// Message to signal the ShaderService to create a Shader
    /// </summary>
    public class CreateShaderMessage : BaseMessage { }
}
