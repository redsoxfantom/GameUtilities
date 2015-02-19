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

    /// <summary>
    /// Message sent when a key is pressed. Does not have any data associated with it,
    /// because the Topic the message is sent on determines what the result of the keypress will be
    /// EX:
    ///     User presses 'W' -> InputService sends a message on the "MOVE_FORWARD" topic
    /// </summary>
    public class KeypressMessage : BaseMessage { }
}
