using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.FilePathResolver;
using System.IO;

namespace GameUtilitiesUnitTests.Worlds
{
    /// <summary>
    /// Test of the WorldFactory class
    /// </summary>
    [TestClass]
    public class WorldFactoryTest
    {
        /// <summary>
        /// Test the create world method with a world that doesn't exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void CreateWorldNoWorld()
        {
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            ConfigManager config = new ConfigManager();
            config.Init(".\\TestConfig");
            execContextMock.Setup(f => f.ConfigManager).Returns(config);

            WorldFactory.CreateWorld("FakeName", execContextMock.Object);
        }
    }
}
