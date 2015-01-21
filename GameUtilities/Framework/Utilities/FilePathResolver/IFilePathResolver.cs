using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilities.Framework.Utilities.FilePathResolver
{
    /// <summary>
    /// Interface for finding the path to various config files
    /// </summary>
    public interface IFilePathResolver
    {
        /// <summary>
        /// Initialize the Service
        /// </summary>
        /// <param name="pathToConfigDirectory">path to the /Config/ directory</param>
        void Init(string pathToConfigDirectory);

        /// <summary>
        /// Finds the Xml document defining a World
        /// </summary>
        /// <param name="worldName">The name of the World to find</param>
        /// <returns>A string with the complete path to the world</returns>
        string FindWorld(string worldName);

        /// <summary>
        /// Finds the Xml document defining an Entity Type
        /// </summary>
        /// <param name="entityTypeName">The name of the entity type to find</param>
        /// <returns>A string with the complete path to the entity type file</returns>
        string FindEntityType(string entityTypeName);

        /// <summary>
        /// Find the name of a Shader file in Config
        /// </summary>
        /// <param name="shaderName">The name of the Shader to find</param>
        /// <returns>The fully qualified path</returns>
        string FindShader(string shaderName);
    }
}
