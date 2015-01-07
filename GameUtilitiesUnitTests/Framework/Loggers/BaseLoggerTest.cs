using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Utilities.Loggers;

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
    }
}
