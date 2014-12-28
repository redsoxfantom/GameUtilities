namespace GameUtilities.Framework
{
    /// <summary>
    /// Interface for anything that must Draw once a frame
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Draw was called</param>
        void Draw(double timeSinceLastFrame);
    }
}
