using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameUtilities.Worlds;
using GameUtilities.Entities;
using GameUtilities.Worlds.DataContracts;
using Moq;
using System.Collections.Generic;
using GameUtilities.Entities.DataContracts;
using GameUtilitiesUnitTests.UnitTestUtilities;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.FilePathResolver;

namespace GameUtilitiesUnitTests.Worlds
{
    /// <summary>
    /// Unit tests of the BaseWorld class
    /// </summary>
    [TestClass]
    public class BaseWorldTest
    {
        BaseWorld target;
        PrivateObject obj;
        Mock<IEntity> entityMock;
        Dictionary<string,IEntity> dict;
        List<IEntity> list;
        LoggerUtility logger;

        /// <summary>
        /// Initializes needed objects before each test
        /// </summary>
        [TestInitialize]
        public void TestIntializer()
        {
            List<EntityData> entities = new List<EntityData>();
            entities.Add(new EntityData("Entity1", "GameUtilities.Entities.BaseEntity,GameUtilities"));
            WorldData data = new WorldData("TEST","TEST",entities);
            target = new BaseWorld(data);
            obj = new PrivateObject(target);
            logger = new LoggerUtility("logger");
            
            entityMock = new Mock<IEntity>();
            entityMock.Setup<string>(f => f.Name).Returns("TEST");
            
            dict = new Dictionary<string, IEntity>();
            dict.Add("TEST", entityMock.Object);
            list = new List<IEntity>();
            list.Add(entityMock.Object);

            obj.SetFieldOrProperty("EntityIdDictionary", dict);
            obj.SetFieldOrProperty("EntityList", list);
            obj.SetFieldOrProperty("mLogger", logger);
        }

        /// <summary>
        /// Test of the constructor
        /// </summary>
        [TestMethod]
        public void WorldConstructorTest()
        {
            Assert.IsNotNull(obj.GetFieldOrProperty("EntityIdDictionary"));
            Assert.IsNotNull(obj.GetFieldOrProperty("EntityList"));
        }

        /// <summary>
        /// Test of the GetEntity method
        /// </summary>
        [TestMethod]
        public void GetEntitySuccessTest()
        {
            IEntity actual = target.GetEntity("TEST");
            Assert.AreEqual(entityMock.Object, actual);
        }

        /// <summary>
        /// Test of the GetEntity method
        /// </summary>
        [TestMethod]
        public void GetEntityFailureTest()
        {
            IEntity actual = target.GetEntity("FAILURE");
            Assert.IsNull(actual);
        }

        /// <summary>
        /// Test the Draw method
        /// </summary>
        [TestMethod]
        public void WorldDrawTest()
        {
            target.Draw(12345);
            entityMock.Verify(f => f.Draw(12345), Times.Once());
        }

        /// <summary>
        /// Test the Update method
        /// </summary>
        [TestMethod]
        public void WorldUpdateTest()
        {
            target.Update(12345);
            entityMock.Verify(f => f.Update(12345), Times.Once());
        }

        /// <summary>
        /// Test the Init method
        /// </summary>
        [TestMethod]
        public void WorldInitSuccessTest()
        {
            List<EntityData> entities = new List<EntityData>();
            entities.Add(new EntityData("TestEntityType", "GameUtilities.Entities.BaseEntity,GameUtilities"));
            WorldData data = new WorldData("TEST", "TEST", entities);
            target = new BaseWorld(data);
            obj = new PrivateObject(target);
            logger = new LoggerUtility("logger");
            obj.SetFieldOrProperty("mLogger", logger);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> routerMock = new Mock<IMessageRouter>();
            ConfigManager config = new ConfigManager();
            config.Init(".\\TestConfig\\");
            contextMock.Setup(f => f.MessageRouter).Returns(routerMock.Object);
            contextMock.Setup(f => f.ConfigManager).Returns(config);

            target.Init(contextMock.Object);

            Assert.IsTrue(logger.ErrorMessages.Count == 0);
            List<IEntity> entList = (List<IEntity>)obj.GetFieldOrProperty("EntityList");
            Dictionary<string, IEntity> EntityIdDictionary = (Dictionary<string, IEntity>)obj.GetFieldOrProperty("EntityIdDictionary");
            Assert.AreEqual(1, entList.Count);
            Assert.AreEqual(1, EntityIdDictionary.Keys.Count);
        }
    }
}
