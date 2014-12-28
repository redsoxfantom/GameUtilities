using GameUtilities.Services.Interfaces;

namespace GameUtilities.Services.Implementations
{
    /// <summary>
    /// Service to allow components to find file paths
    /// </summary>
    public class FilePathResolverService : IFilePathResolverService
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
        public FilePathResolverService()
        {
            mRootDirectory = string.Empty;
        }

        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="pathToConfigDirectory">path to the /Config/ directory</param>
        void Init(string pathToConfigDirectory)
        {
            mRootDirectory = pathToConfigDirectory;
        }

        /// <summary>
        /// Finds the Xml document defining a World
        /// </summary>
        /// <param name="worldName">The name of the World to find</param>
        /// <returns>A string with the complete path to the world</returns>
        string FindWorld(string worldName)
        {
            return mRootDirectory + "\\Worlds\\" + worldName + ".xml";
        }

        /// <summary>
        /// Finds the Xml document defining an Entity Type
        /// </summary>
        /// <param name="entityTypeName">The name of the entity type to find</param>
        /// <returns>A string with the complete path to the entity type file</returns>
        string FindEntityType(string entityTypeName)
        {
            return mRootDirectory + "\\EntityTypes\\" + entityTypeName + ".xml";
        }
        #endregion IFilePathResolverService Methods
    }
}
