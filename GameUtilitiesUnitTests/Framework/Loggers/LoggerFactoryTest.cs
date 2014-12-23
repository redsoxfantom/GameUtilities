using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Loggers;

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
            bool debugEnabled = false;
#if DEBUG
            debugEnabled = true;
#endif
            ILogger obj = LoggerFactory.CreateLogger("TEST");

            if(debugEnabled)
            {
                Assert.IsInstanceOfType(obj, typeof(ConsoleLogger));
            }
            else
            {
                Assert.IsInstanceOfType(obj, typeof(NullLogger));
            }
            
        }
    }
}
