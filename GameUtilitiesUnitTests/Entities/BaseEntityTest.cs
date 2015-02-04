using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Entities;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Components;
using GameUtilities.Framework.Utilities.FilePathResolver;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilitiesUnitTests.UnitTestUtilities;

namespace GameUtilitiesUnitTests.Entities
{
    /// <summary>
    /// Summary description for BaseEntityTest
    /// </summary>
    [TestClass]
    public class BaseEntityTest
    {
        BaseEntity target;
        PrivateObject po;
        Mock<IComponent> componentMock;
        List<IComponent> list;

        /// <summary>
        /// Initialize unit tests
        /// </summary>
        [TestInitialize]
        public void Initializer()
        {
            target = new BaseEntity(new EntityData("TestEntityType","ASSEMBLY"));
            po = new PrivateObject(target);
            componentMock = new Mock<IComponent>();
            list = new List<IComponent>();
            list.Add(componentMock.Object);
            po.SetFieldOrProperty("mComponents", list);
        }

        /// <summary>
        /// Test Constructor
        /// </summary>
        [TestMethod]
        public void BaseEntityConstructorTest()
        {
            String mName = (String)po.GetFieldOrProperty("mName");
            mName = mName.Substring(0, 4);

            Assert.AreEqual("Test", mName);
        }

        /// <summary>
        /// Test the init method
        /// </summary>
        [TestMethod]
        public void BaseEntityInitTest()
        {
            target = new BaseEntity(new EntityData("TestEntityType", "ASSEMBLY"));
            po = new PrivateObject(target);
            ConfigManager config = new ConfigManager();
            config.Init(".\\TestConfig");
            LoggerUtility logger = new LoggerUtility("entity");
            Mock<IMessageRouter> mockRouter = new Mock<IMessageRouter>();
            Mock<IExecutableContext> mockContext = new Mock<IExecutableContext>();
            Mock<IEntity> entityMock = new Mock<IEntity>();
            mockContext.Setup(f => f.MessageRouter).Returns(mockRouter.Object);
            mockContext.Setup(f => f.ConfigManager).Returns(config);
            mockContext.Setup(f => f.Entity).Returns(entityMock.Object);
            po.SetFieldOrProperty("mLogger", logger);

            target.Init(mockContext.Object);

            List<IComponent> componentList = (List<IComponent>)po.GetFieldOrProperty("mComponents");
            Assert.IsTrue(componentList.Count == 1);
            Assert.IsTrue(logger.ErrorMessages.Count == 0);
        }

        /// <summary>
        /// Test the Draw Method
        /// </summary>
        [TestMethod]
        public void EntityDrawTest()
        {
            target.Draw(12345);
            componentMock.Verify(f => f.Draw(12345), Times.Once());
        }

        /// <summary>
        /// Test the Update Method
        /// </summary>
        [TestMethod]
        public void EntityUpdateTest()
        {
            target.Update(12345);
            componentMock.Verify(f => f.Update(12345), Times.Once());
        }
    }
}
