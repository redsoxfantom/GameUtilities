namespace GameUtilities.Framework
{
    /// <summary>
    /// Interface for anything that must Update once a frame
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="timeSinceLastFrame">How long its been since the last time Update was called</param>
        void Update(double timeSinceLastFrame);
    }
}
