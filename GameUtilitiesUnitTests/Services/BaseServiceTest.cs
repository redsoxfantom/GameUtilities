using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Services;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Loggers;

namespace GameUtilitiesUnitTests.Services
{
    /// <summary>
    /// Test for the Base Service class
    /// </summary>
    [TestClass]
    public class BaseServiceTest
    {
        /// <summary>
        /// Test of the Constructor
        /// </summary>
        [TestMethod]
        public void BaseServiceConstructorTest()
        {
            BaseService target = new BaseService();
            PrivateObject obj = new PrivateObject(target);
            obj.SetFieldOrProperty("mLogger", new Mock<ILogger>().Object);

            string expectedName = "BaseService";
            string actualName = (string)obj.GetFieldOrProperty("mName");

            Assert.AreEqual(expectedName, actualName);
        }

        /// <summary>
        /// Test of the init method
        /// </summary>
        [TestMethod]
        public void BaseServiceInitTest()
        {
            BaseService target = new BaseService();
            PrivateObject obj = new PrivateObject(target);
            obj.SetFieldOrProperty("mLogger", new Mock<ILogger>().Object);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();

            target.Init(contextMock.Object);

            IExecutableContext expectedContext = contextMock.Object;
            IExecutableContext actualContext = (IExecutableContext)obj.GetFieldOrProperty("mContext");

            Assert.AreEqual(expectedContext, actualContext);
        }
    }
}
