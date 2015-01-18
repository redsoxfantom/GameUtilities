using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Utilities.Loggers;

namespace GameUtilitiesUnitTests.Framework.Loggers
{
    /// <summary>
    /// Summary description for LoggerFactoryTest
    /// </summary>
    [TestClass]
    public class LoggerFactoryTest
    {
        /// <summary>
        /// Test logger creator
        /// </summary>
        [TestMethod]
        public void CreateLoggerTest()
        {
            LoggerFactory.SetLoggerType(typeof(ConsoleLogger));

            ILogger logger = LoggerFactory.CreateLogger("TEST");

            Assert.IsTrue(logger.GetType() == typeof(ConsoleLogger));
        }
    }
}
