using OpenTK.Input;

namespace GameUtilities.Framework.Utilities.InputHandlers
{
    /// <summary>
    /// Class that reads in from all connected inputs.
    /// </summary>
    public class InputHandler : IInputHandler
    {
        private KeyboardState keyboard;

        /// <summary>
        /// Read in all connected inputs
        /// </summary>
        public void GetInputs()
        {
            keyboard = Keyboard.GetState();
        }

        /// <summary>
        /// Check if a key is currently pressed
        /// </summary>
        /// <param name="key">key to check</param>
        /// <returns>whether or not the key is pressed</returns>
        public bool isKeyDown(Key key)
        {
            return keyboard[key];
        }
    }
}
