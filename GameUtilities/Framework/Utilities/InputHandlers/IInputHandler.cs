using OpenTK.Input;

namespace GameUtilities.Framework.Utilities.InputHandlers
{
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
