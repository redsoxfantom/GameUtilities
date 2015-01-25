using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Engine;
using GameUtilities.Worlds;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilitiesUnitTests.UnitTestUtilities;

namespace GameUtilitiesUnitTests.Framework
{
    /// <summary>
    /// Test for the Engine class
    /// </summary>
    [TestClass]
    public class EngineTest
    {
        /// <summary>
        /// Test the Init method
        /// </summary>
        [TestMethod]
        public void EngineInitTest()
        {
            Engine target = new Engine();
            PrivateObject obj = new PrivateObject(target);
            LoggerUtility logger = new LoggerUtility("logger");
            obj.SetFieldOrProperty("mLogger", logger);

            target.Init("Test", "Test");

            Assert.IsTrue(logger.WarnMessages.Count == 1);
        }

        /// <summary>
        /// Test the Update method
        /// </summary>
        [TestMethod]
        public void EngineUpdateTest()
        {
            Engine target = new Engine();
            PrivateObject obj = new PrivateObject(target);
            Mock<IWorld> worldMock = new Mock<IWorld>();
            IExecutableContext mContext = new BaseExecutableContext("TEST");
            obj.SetFieldOrProperty("mWorld", worldMock.Object);
            obj.SetFieldOrProperty("mContext", mContext);

            target.Update(12345);
            worldMock.Verify(f => f.Update(12345), Times.Once());
        }


        /// <summary>
        /// Test the Draw method
        /// </summary>
        [TestMethod]
        public void EngineDrawTest()
        {
            Engine target = new Engine();
            PrivateObject obj = new PrivateObject(target);
            Mock<IWorld> worldMock = new Mock<IWorld>();
            obj.SetFieldOrProperty("mWorld", worldMock.Object);

            target.Draw(12345);
            worldMock.Verify(f => f.Draw(12345), Times.Once());
        }
    }
}
