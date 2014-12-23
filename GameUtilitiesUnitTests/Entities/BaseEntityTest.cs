using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Entities;

namespace GameUtilitiesUnitTests.Entities
{
    /// <summary>
    /// Summary description for BaseEntityTest
    /// </summary>
    [TestClass]
    public class BaseEntityTest
    {
        /// <summary>
        /// Test Constructor
        /// </summary>
        [TestMethod]
        public void BaseEntityConstructorTest()
        {
            BaseEntity target = new BaseEntity("TEST");
            PrivateObject po = new PrivateObject(target);

            String mName = (String)po.GetFieldOrProperty("mName");
            mName = mName.Substring(0, 5);

            Assert.AreEqual("TEST.", mName);
        }
    }
}
