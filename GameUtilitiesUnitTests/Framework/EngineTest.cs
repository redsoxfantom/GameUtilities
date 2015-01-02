using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Engine;
using GameUtilities.Worlds;

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
        [ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
        public void EngineInitTest()
        {
            Engine target = new Engine();
            PrivateObject obj = new PrivateObject(target);

            target.Init("Test", "Test");
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
            obj.SetFieldOrProperty("mWorld", worldMock.Object);

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
