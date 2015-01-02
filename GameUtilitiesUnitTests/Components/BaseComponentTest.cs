using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameUtilities.Framework.DataContracts;
using GameUtilities.Components;
using GameUtilities.Framework;
using GameUtilities.Entities;
using Moq;

namespace GameUtilitiesUnitTests.Components
{
    /// <summary>
    /// Test for all methods in Base Component
    /// </summary>
    [TestClass]
    public class BaseComponentTest
    {
        /// <summary>
        /// Test the constructor of the BaseComponent
        /// </summary>
        [TestMethod]
        public void BaseComponentConstructor()
        {
            DataSet data = new DataSet();
            BaseComponent comp = new BaseComponent(data);
            PrivateObject obj = new PrivateObject(comp);

            DataSet actual = (DataSet)obj.GetFieldOrProperty("mDataSet");
            Assert.AreEqual(data, actual);
        }

        /// <summary>
        /// Test method for the BaseComponent Init method
        /// </summary>
        [TestMethod]
        public void BaseComponentInitTest()
        {
            DataSet data = new DataSet();
            BaseComponent comp = new BaseComponent(data);
            PrivateObject obj = new PrivateObject(comp);
            ExecutableContext mContext = new ExecutableContext("test");
            Mock<IEntity> entityMock = new Mock<IEntity>().SetupAllProperties();
            entityMock.Setup(f => f.Name).Returns("TEST");
            mContext.Entity = entityMock.Object;

            comp.Init(mContext);
            string actual = (string)obj.GetFieldOrProperty("mName");
            string expected = "BaseComponent@TEST";

            Assert.AreEqual(expected, actual);
        }
    }
}
