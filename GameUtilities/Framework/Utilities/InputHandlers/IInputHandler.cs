using OpenTK.Input;

namespace GameUtilities.Framework.Utilities.InputHandlers
{
    /// <summary>
    /// Interface for checking user inputs
    /// Provides functions for reading in from all connected input devices
    /// and checking if particular keys are pressed
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Read in all connected inputs
        /// </summary>
        void GetInputs();

        /// <summary>
        /// Check if a key is currently pressed
        /// </summary>
        /// <param name="key">key to check</param>
        /// <returns>whether or not the key is pressed</returns>
        bool isKeyDown(Key key);
    }
}
