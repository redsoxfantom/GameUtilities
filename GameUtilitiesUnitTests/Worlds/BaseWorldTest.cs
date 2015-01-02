using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameUtilities.Worlds;
using GameUtilities.Entities;
using GameUtilities.Worlds.DataContracts;
using Moq;
using System.Collections.Generic;

namespace GameUtilitiesUnitTests.Worlds
{
    /// <summary>
    /// Unit tests of the BaseWorld class
    /// </summary>
    [TestClass]
    public class BaseWorldTest
    {
        BaseWorld target;
        PrivateObject obj;
        Mock<IEntity> entityMock;
        Dictionary<string,IEntity> dict;
        List<IEntity> list;

        /// <summary>
        /// Initializes needed objects before each test
        /// </summary>
        [TestInitialize]
        public void TestIntializer()
        {
            target = new BaseWorld(new WorldData("TEST","TEST"));
            obj = new PrivateObject(target);
            
            entityMock = new Mock<IEntity>();
            entityMock.Setup<string>(f => f.Name).Returns("TEST");
            
            dict = new Dictionary<string, IEntity>();
            dict.Add("TEST", entityMock.Object);
            list = new List<IEntity>();
            list.Add(entityMock.Object);

            obj.SetFieldOrProperty("EntityIdDictionary", dict);
            obj.SetFieldOrProperty("EntityList", list);
        }

        /// <summary>
        /// Test of the constructor
        /// </summary>
        [TestMethod]
        public void WorldConstructorTest()
        {
            Assert.IsNotNull(obj.GetFieldOrProperty("EntityIdDictionary"));
            Assert.IsNotNull(obj.GetFieldOrProperty("EntityList"));
        }

        /// <summary>
        /// Test of the GetEntity method
        /// </summary>
        [TestMethod]
        public void GetEntityTest()
        {
            IEntity actual = target.GetEntity("TEST");
            Assert.AreEqual(entityMock.Object, actual);

            actual = target.GetEntity("FAILURE");
            Assert.IsNull(actual);
        }

        /// <summary>
        /// Test the Draw method
        /// </summary>
        [TestMethod]
        public void WorldDrawTest()
        {
            target.Draw(12345);
            entityMock.Verify(f => f.Draw(12345), Times.Once());
        }

        /// <summary>
        /// Test the Update method
        /// </summary>
        [TestMethod]
        public void WorldUpdateTest()
        {
            target.Update(12345);
            entityMock.Verify(f => f.Update(12345), Times.Once());
        }

        /// <summary>
        /// Test the Init method
        /// </summary>
        [TestMethod]
        public void WorldInitTest()
        {
            //TODO: fill in this test when Init is complete
        }
    }
}
