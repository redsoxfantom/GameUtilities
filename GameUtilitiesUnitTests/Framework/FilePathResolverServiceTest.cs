using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Framework.Utilities.FilePathResolver;

namespace GameUtilitiesUnitTests.Services
{
    /// <summary>
    /// Test class for verifiying the FilePathResolverService class
    /// </summary>
    [TestClass]
    public class FilePathResolverServiceTest
    {
        /// <summary>
        /// The path to the config directory
        /// </summary>
        string path = "/Path/To/Config";

        /// <summary>
        /// the test target
        /// </summary>
        ConfigManager target;

        /// <summary>
        /// Used to access private fields
        /// </summary>
        PrivateObject po;

        /// <summary>
        /// Test initializer method
        /// </summary>
        [TestInitialize]
        public void Initializer()
        {
            target = new ConfigManager();
            po = new PrivateObject(target);
        }

        /// <summary>
        /// Test the Init method
        /// </summary>
        [TestMethod]
        public void FilePathResolverInitTest()
        {
            target.Init(path);
            string actual = (string)po.GetFieldOrProperty("mRootDirectory");
            Assert.AreEqual(path, actual);
        }

        /// <summary>
        /// Test the FindWorld method with an Init call
        /// </summary>
        [TestMethod]
        public void FindWorldTestWithInit()
        {
            target.Init(path);
            string expected = path + "\\Worlds\\TEST.xml";
            string actual = target.FindWorld("TEST");

            Assert.AreEqual(expected,actual);
        }

        /// <summary>
        /// Test the FindWorld method with no Init
        /// </summary>
        [TestMethod]
        public void FindWorldTestWithNoInit()
        {
            string expected = "\\Worlds\\TEST.xml";
            string actual = target.FindWorld("TEST");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the FindEntityType method with an Init call
        /// </summary>
        [TestMethod]
        public void FindEntityTypeTestWithInit()
        {
            target.Init(path);
            string expected = path + "\\EntityTypes\\TEST.xml";
            string actual = target.FindEntityType("TEST");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the FindEntityType method with np Init call
        /// </summary>
        [TestMethod]
        public void FindEntityTypeTestWithNoInit()
        {
            string expected = "\\EntityTypes\\TEST.xml";
            string actual = target.FindEntityType("TEST");

            Assert.AreEqual(expected, actual);
        }
    }
}
