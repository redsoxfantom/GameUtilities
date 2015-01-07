namespace GameUtilities.Framework.Utilities.FilePathResolver
{
    /// <summary>
    /// Service to allow components to find file paths
    /// </summary>
    public class ConfigManager : IFilePathResolver
    {
        #region Fields
        /// <summary>
        /// Stores the location of the Root config directory
        /// </summary>
        private string mRootDirectory;
        #endregion Fields

        #region IFilePathResolverService Methods
        /// <summary>
        /// The constructor
        /// </summary>
        public ConfigManager()
        {
            mRootDirectory = string.Empty;
        }

        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="pathToConfigDirectory">path to the /Config/ directory</param>
        public void Init(string pathToConfigDirectory)
        {
            mRootDirectory = pathToConfigDirectory;
        }

        /// <summary>
        /// Finds the Xml document defining a World
        /// </summary>
        /// <param name="worldName">The name of the World to find</param>
        /// <returns>A string with the complete path to the world</returns>
        public string FindWorld(string worldName)
        {
            return mRootDirectory + "\\Worlds\\" + worldName + ".xml";
        }

        /// <summary>
        /// Finds the Xml document defining an Entity Type
        /// </summary>
        /// <param name="entityTypeName">The name of the entity type to find</param>
        /// <returns>A string with the complete path to the entity type file</returns>
        public string FindEntityType(string entityTypeName)
        {
            return mRootDirectory + "\\EntityTypes\\" + entityTypeName + ".xml";
        }
        #endregion IFilePathResolverService Methods
    }
}
