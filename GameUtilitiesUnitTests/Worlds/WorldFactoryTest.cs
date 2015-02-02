using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Worlds.DataContracts;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.FilePathResolver;
using System.IO;
using GameUtilities.Worlds;
using System.Collections.Generic;
using GameUtilities.Entities;
using GameUtilitiesUnitTests.UnitTestUtilities;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;

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
        [ExpectedException(typeof(FileNotFoundException))]
        public void CreateWorldInvalid()
        {
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            ConfigManager config = new ConfigManager();
            config.Init(".\\TestConfig");
            execContextMock.Setup(f => f.ConfigManager).Returns(config);

            WorldFactory.CreateWorld("FakeName", execContextMock.Object);
        }

        /// <summary>
        /// Test the create world method with a world that exists
        /// </summary>
        [TestMethod]
        public void CreateWorldValid()
        {
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
            ConfigManager config = new ConfigManager();
            config.Init(".\\TestConfig");
            execContextMock.Setup(f => f.ConfigManager).Returns(config);
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);

            BaseWorld world = (BaseWorld)WorldFactory.CreateWorld("World1", execContextMock.Object);

            PrivateObject obj = new PrivateObject(world);
            List<IEntity> EntityList = (List<IEntity>)obj.GetFieldOrProperty("EntityList");
            Assert.IsTrue(EntityList.Count == 2);
            Assert.IsTrue(EntityList[0].GetType() == typeof(BaseEntity));
            Assert.IsTrue(EntityList[1].GetType() == typeof(BaseEntity));
        }
    }
}
