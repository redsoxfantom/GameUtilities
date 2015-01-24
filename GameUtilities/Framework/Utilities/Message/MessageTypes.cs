namespace GameUtilities.Framework.Utilities.Message
{
    /// <summary>
    /// Message for updates to the Camera Matrix
    /// </summary>
    public class CameraMatrixMessage : BaseMessage {}

    /// <summary>
    /// Message to signal the ShaderService to load a shader from a file
    /// Expects a Dictionary of ShaderType-string, where ShaderType is the type of shader to create
    /// and string is the filename defining the shader
    /// </summary>
    public class LoadShaderProgramMessage : BaseMessage { }
}
