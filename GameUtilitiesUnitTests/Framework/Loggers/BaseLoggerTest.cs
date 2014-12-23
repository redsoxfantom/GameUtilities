using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Loggers;

namespace GameUtilitiesUnitTests.Framework.Loggers
{
    /// <summary>
    /// Summary description for BaseLoggerTest
    /// </summary>
    [TestClass]
    public class BaseLoggerTest
    {
        /// <summary>
        /// Test the constructor
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            BaseLogger target = new BaseLogger("TEST");

            Assert.AreEqual(target.LoggerName, "TEST");
            Assert.AreEqual(target.LoggingLevel, LoggerLevel.INFO);

            target = new BaseLogger("TEST", LoggerLevel.FATAL);

            Assert.AreEqual(target.LoggerName, "TEST");
            Assert.AreEqual(target.LoggingLevel, LoggerLevel.FATAL);
        }

        /// <summary>
        /// Test log levels
        /// </summary>
        [TestMethod]
        public void LogLevelsTest()
        {
            BaseLogger target = new BaseLogger("TEST",LoggerLevel.ERROR);

            Assert.IsTrue(target.ErrorEnabled());
            Assert.IsFalse(target.WarnEnabled());
        }

        /// <summary>
        /// Test child loggers
        /// </summary>
        [TestMethod]
        public void ChildLoggersTest()
        {
            BaseLogger target = new BaseLogger("TEST", LoggerLevel.ERROR);
            PrivateObject po = new PrivateObject(target);

            Mock<ILogger> childLoggerMock1 = new Mock<ILogger>();
            Mock<ILogger> childLoggerMock2 = new Mock<ILogger>();
            target.AddChildLogger(childLoggerMock1.Object);
            target.AddChildLogger(childLoggerMock2.Object);
            List<ILogger> childLoggers = (List<ILogger>)po.GetFieldOrProperty("childLoggers");

            Assert.AreEqual<int>(childLoggers.Count, 2);

            target.RemoveChildLogger(childLoggerMock1.Object);

            Assert.AreEqual<int>(childLoggers.Count, 1);
        }

        /// <summary>
        /// Test setting Log Levels
        /// </summary>
        [TestMethod]
        public void SetLogLevelsTest()
        {
            BaseLogger target = new BaseLogger("TEST", LoggerLevel.ERROR);
            PrivateObject po = new PrivateObject(target);

            BaseLogger childLogger = new BaseLogger("Test2", LoggerLevel.DEBUG);
            target.AddChildLogger(childLogger);

            Assert.AreEqual(childLogger.LoggingLevel, LoggerLevel.ERROR);

            target.LoggingLevel = LoggerLevel.DEBUG;

            Assert.AreEqual(childLogger.LoggingLevel, LoggerLevel.DEBUG);
        }
    }
}
