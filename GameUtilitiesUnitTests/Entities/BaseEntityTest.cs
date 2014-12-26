using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Entities;
using GameUtilities.Entities.DataContracts;
using GameUtilities.Components;

namespace GameUtilitiesUnitTests.Entities
{
    /// <summary>
    /// Summary description for BaseEntityTest
    /// </summary>
    [TestClass]
    public class BaseEntityTest
    {
        BaseEntity target;
        PrivateObject po;
        Mock<IComponent> componentMock;
        List<IComponent> list;

        /// <summary>
        /// Initialize unit tests
        /// </summary>
        [TestInitialize]
        public void Initializer()
        {
            target = new BaseEntity(new EntityData("TEST"));
            po = new PrivateObject(target);
            componentMock = new Mock<IComponent>();
            list = new List<IComponent>();
            list.Add(componentMock.Object);
            po.SetFieldOrProperty("mComponents", list);
        }

        /// <summary>
        /// Test Constructor
        /// </summary>
        [TestMethod]
        public void BaseEntityConstructorTest()
        {
            String mName = (String)po.GetFieldOrProperty("mName");
            mName = mName.Substring(0, 5);

            Assert.AreEqual("TEST.", mName);
        }

        /// <summary>
        /// Test the init method
        /// </summary>
        [TestMethod]
        public void InitTest()
        {
            //TODO: fill this in when Init is finalized
        }

        /// <summary>
        /// Test the Draw Method
        /// </summary>
        [TestMethod]
        public void EntityDrawTest()
        {
            target.Draw(12345);
            componentMock.Verify(f => f.Draw(12345), Times.Once());
        }

        /// <summary>
        /// Test the Update Method
        /// </summary>
        [TestMethod]
        public void EntityUpdateTest()
        {
            target.Update(12345);
            componentMock.Verify(f => f.Update(12345), Times.Once());
        }
    }
}
