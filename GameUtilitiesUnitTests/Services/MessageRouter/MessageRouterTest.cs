using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Services.MessageRouter;
using GameUtilities.Framework.Utilities.Message;

namespace GameUtilitiesUnitTests.Services.MessageRouter
{
    /// <summary>
    /// Test for the Message Router service
    /// </summary>
    [TestClass]
    public class MessageRouterTest
    {
        /// <summary>
        /// Test for message registration
        /// </summary>
        [TestMethod]
        public void RegisterTopicTest()
        {
            MessageRouterService target = new MessageRouterService();
            PrivateObject obj = new PrivateObject(target);
        }
    }
}
