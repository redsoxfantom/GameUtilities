﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Components;
using GameUtilities.Framework.DataContracts;
using GameUtilities.Components.Constants.Camera;
using GameUtilities.Framework.Utilities.ExecutableContext;
using OpenTK;
using System.Collections.Generic;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.Message;
using GameUtilitiesUnitTests.UnitTestUtilities;
using GameUtilities.Framework.Utilities.Loggers;

namespace GameUtilitiesUnitTests.Components
{
    /// <summary>
    /// Test for the CameraComponent class
    /// </summary>
    [TestClass]
    public class CameraComponentTest
    {
        /// <summary>
        /// Successful test of the init method for Ortho cameras
        /// </summary>
        [TestMethod]
        public void CameraOrthoInitTestSuccess()
        {
            DataSet set = new DataSet();
            set.Add(ComponentConstants.CAMERA_POS_X, "0.1");
            set.Add(ComponentConstants.CAMERA_POS_Y, "0.2");
            set.Add(ComponentConstants.CAMERA_POS_Z, "0.3");
            set.Add(ComponentConstants.CAMERA_TARGET_X, "0.4");
            set.Add(ComponentConstants.CAMERA_TARGET_Y, "0.5");
            set.Add(ComponentConstants.CAMERA_TARGET_Z, "0.6");
            set.Add(ComponentConstants.CAMERA_UP_X, "0.7");
            set.Add(ComponentConstants.CAMERA_UP_Y, "0.8");
            set.Add(ComponentConstants.CAMERA_UP_Z, "0.9");
            set.Add(ComponentConstants.CAMERA_ZNEAR, "1.0");
            set.Add(ComponentConstants.CAMERA_ZFAR, "1.1");
            set.Add(ComponentConstants.CAMERA_TYPE, Enum.GetName(typeof(ComponentConstants.CAM_TYPES),ComponentConstants.CAM_TYPES.ORTHOGRAPHIC));
            set.Add(ComponentConstants.CAMERA_WIDTH, "1.2");
            set.Add(ComponentConstants.CAMERA_HEIGHT, "1.3");

            CameraComponent target = new CameraComponent();
            PrivateObject obj = new PrivateObject(target);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> routerMock = new Mock<IMessageRouter>();
            contextMock.Setup(f => f.Entity.Name).Returns("TEST");
            contextMock.Setup(f => f.MessageRouter).Returns(routerMock.Object);


            target.Init(contextMock.Object, set);
            

            Vector3d actualPos = (Vector3d)obj.GetFieldOrProperty("Pos");
            Vector3d actualTarget = (Vector3d)obj.GetFieldOrProperty("Target");
            Vector3d actualUp = (Vector3d)obj.GetFieldOrProperty("Up");
            Vector3d expectedPos = new Vector3d(0.1, 0.2, 0.3);
            Vector3d expectedTarget = new Vector3d(0.4, 0.5, 0.6);
            Vector3d expectedUp = new Vector3d(0.7, 0.8, 0.9);
            double actualZNear = (double)obj.GetFieldOrProperty("zNear");
            double actualZFar = (double)obj.GetFieldOrProperty("zFar");
            double expectedZNear = 1.0;
            double expectedZFar = 1.1;
            ComponentConstants.CAM_TYPES actualCameraType = (ComponentConstants.CAM_TYPES)obj.GetFieldOrProperty("cameraType");
            ComponentConstants.CAM_TYPES expectedCameraType = ComponentConstants.CAM_TYPES.ORTHOGRAPHIC;
            double actualWidth = (double)obj.GetFieldOrProperty("cameraWidth");
            double actualHeight = (double)obj.GetFieldOrProperty("cameraHeight");
            double expectedWidth = 1.2;
            double expectedHeight = 1.3;

            Assert.IsTrue(actualPos.Equals(expectedPos));
            Assert.IsTrue(actualTarget.Equals(expectedTarget));
            Assert.IsTrue(actualUp.Equals(expectedUp));
            Assert.AreEqual(expectedZFar, actualZFar);
            Assert.AreEqual(expectedZNear, actualZNear);
            Assert.AreEqual(expectedCameraType, actualCameraType);
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        /// <summary>
        /// Successful test of the init method for Perspective cameras
        /// </summary>
        [TestMethod]
        public void CameraPerspectiveInitTestSuccess()
        {
            DataSet set = new DataSet();
            set.Add(ComponentConstants.CAMERA_POS_X, "0.1");
            set.Add(ComponentConstants.CAMERA_POS_Y, "0.2");
            set.Add(ComponentConstants.CAMERA_POS_Z, "0.3");
            set.Add(ComponentConstants.CAMERA_TARGET_X, "0.4");
            set.Add(ComponentConstants.CAMERA_TARGET_Y, "0.5");
            set.Add(ComponentConstants.CAMERA_TARGET_Z, "0.6");
            set.Add(ComponentConstants.CAMERA_UP_X, "0.7");
            set.Add(ComponentConstants.CAMERA_UP_Y, "0.8");
            set.Add(ComponentConstants.CAMERA_UP_Z, "0.9");
            set.Add(ComponentConstants.CAMERA_ZNEAR, "1.0");
            set.Add(ComponentConstants.CAMERA_ZFAR, "1.1");
            set.Add(ComponentConstants.CAMERA_TYPE, Enum.GetName(typeof(ComponentConstants.CAM_TYPES), ComponentConstants.CAM_TYPES.PERSPECTIVE));
            set.Add(ComponentConstants.CAMERA_FOV, "1.2");
            set.Add(ComponentConstants.CAMERA_ASPECT, "1.3");

            CameraComponent target = new CameraComponent();
            PrivateObject obj = new PrivateObject(target);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> routerMock = new Mock<IMessageRouter>();
            contextMock.Setup(f => f.Entity.Name).Returns("TEST");
            contextMock.Setup(f => f.MessageRouter).Returns(routerMock.Object);


            target.Init(contextMock.Object, set);


            Vector3d actualPos = (Vector3d)obj.GetFieldOrProperty("Pos");
            Vector3d actualTarget = (Vector3d)obj.GetFieldOrProperty("Target");
            Vector3d actualUp = (Vector3d)obj.GetFieldOrProperty("Up");
            Vector3d expectedPos = new Vector3d(0.1, 0.2, 0.3);
            Vector3d expectedTarget = new Vector3d(0.4, 0.5, 0.6);
            Vector3d expectedUp = new Vector3d(0.7, 0.8, 0.9);
            double actualZNear = (double)obj.GetFieldOrProperty("zNear");
            double actualZFar = (double)obj.GetFieldOrProperty("zFar");
            double expectedZNear = 1.0;
            double expectedZFar = 1.1;
            ComponentConstants.CAM_TYPES actualCameraType = (ComponentConstants.CAM_TYPES)obj.GetFieldOrProperty("cameraType");
            ComponentConstants.CAM_TYPES expectedCameraType = ComponentConstants.CAM_TYPES.PERSPECTIVE;
            double actualFOV = (double)obj.GetFieldOrProperty("cameraFOV");
            double actualAspect = (double)obj.GetFieldOrProperty("cameraAspect");
            double expectedFOV = 1.2;
            double expectedAspect = 1.3;

            Assert.IsTrue(actualPos.Equals(expectedPos));
            Assert.IsTrue(actualTarget.Equals(expectedTarget));
            Assert.IsTrue(actualUp.Equals(expectedUp));
            Assert.AreEqual(expectedZFar, actualZFar);
            Assert.AreEqual(expectedZNear, actualZNear);
            Assert.AreEqual(expectedCameraType, actualCameraType);
            Assert.AreEqual(expectedFOV, actualFOV);
            Assert.AreEqual(expectedAspect, actualAspect);
        }

        /// <summary>
        /// A failure test of the Camera Init method
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void CameraInitFailureTest()
        {
            DataSet set = new DataSet();

            CameraComponent target = new CameraComponent();
            PrivateObject obj = new PrivateObject(target);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> routerMock = new Mock<IMessageRouter>();
            contextMock.Setup(f => f.Entity.Name).Returns("TEST");
            contextMock.Setup(f => f.MessageRouter).Returns(routerMock.Object);

            target.Init(contextMock.Object, set);
        }

        /// <summary>
        /// Test the Camera Update method without the Dirty flag set
        /// </summary>
        [TestMethod]
        public void CameraInitNoDirtyFlag()
        {
            DataSet set = new DataSet();
            set.Add(ComponentConstants.CAMERA_POS_X, "0.1");
            set.Add(ComponentConstants.CAMERA_POS_Y, "0.2");
            set.Add(ComponentConstants.CAMERA_POS_Z, "0.3");
            set.Add(ComponentConstants.CAMERA_TARGET_X, "0.4");
            set.Add(ComponentConstants.CAMERA_TARGET_Y, "0.5");
            set.Add(ComponentConstants.CAMERA_TARGET_Z, "0.6");
            set.Add(ComponentConstants.CAMERA_UP_X, "0.7");
            set.Add(ComponentConstants.CAMERA_UP_Y, "0.8");
            set.Add(ComponentConstants.CAMERA_UP_Z, "0.9");
            set.Add(ComponentConstants.CAMERA_ZNEAR, "1.0");
            set.Add(ComponentConstants.CAMERA_ZFAR, "1.1");
            set.Add(ComponentConstants.CAMERA_TYPE, Enum.GetName(typeof(ComponentConstants.CAM_TYPES), ComponentConstants.CAM_TYPES.PERSPECTIVE));
            set.Add(ComponentConstants.CAMERA_FOV, "1.2");
            set.Add(ComponentConstants.CAMERA_ASPECT, "1.3");
            CameraComponent target = new CameraComponent();
            PrivateObject obj = new PrivateObject(target);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> routerMock = new Mock<IMessageRouter>();
            contextMock.Setup(f => f.Entity.Name).Returns("TEST");
            contextMock.Setup(f => f.MessageRouter).Returns(routerMock.Object);
            target.Init(contextMock.Object, set);
            bool isDirty = false;
            obj.SetFieldOrProperty("isDirty", isDirty);

            target.Update(0);

            Assert.IsFalse((bool)obj.GetFieldOrProperty("isDirty"));
            routerMock.Verify(f=>f.SendMessage(MessagingConstants.CAMERA_MATRIX_TOPIC,It.IsAny<IMessage>()),Times.Never());
        }

        /// <summary>
        /// Test the Camera Update method with the Dirty flag set
        /// </summary>
        [TestMethod]
        public void CameraInitDirtyFlag()
        {
            DataSet set = new DataSet();
            set.Add(ComponentConstants.CAMERA_POS_X, "0.1");
            set.Add(ComponentConstants.CAMERA_POS_Y, "0.2");
            set.Add(ComponentConstants.CAMERA_POS_Z, "0.3");
            set.Add(ComponentConstants.CAMERA_TARGET_X, "0.4");
            set.Add(ComponentConstants.CAMERA_TARGET_Y, "0.5");
            set.Add(ComponentConstants.CAMERA_TARGET_Z, "0.6");
            set.Add(ComponentConstants.CAMERA_UP_X, "0.7");
            set.Add(ComponentConstants.CAMERA_UP_Y, "0.8");
            set.Add(ComponentConstants.CAMERA_UP_Z, "0.9");
            set.Add(ComponentConstants.CAMERA_ZNEAR, "1.0");
            set.Add(ComponentConstants.CAMERA_ZFAR, "1.1");
            set.Add(ComponentConstants.CAMERA_TYPE, Enum.GetName(typeof(ComponentConstants.CAM_TYPES), ComponentConstants.CAM_TYPES.PERSPECTIVE));
            set.Add(ComponentConstants.CAMERA_FOV, "1.2");
            set.Add(ComponentConstants.CAMERA_ASPECT, "1.3");
            CameraComponent target = new CameraComponent();
            PrivateObject obj = new PrivateObject(target);
            Mock<IExecutableContext> contextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> routerMock = new Mock<IMessageRouter>();
            contextMock.Setup(f => f.Entity.Name).Returns("TEST");
            contextMock.Setup(f => f.MessageRouter).Returns(routerMock.Object);
            target.Init(contextMock.Object, set);
            bool isDirty = true;
            obj.SetFieldOrProperty("isDirty", isDirty);

            target.Update(0);

            Assert.IsFalse((bool)obj.GetFieldOrProperty("isDirty"));
            routerMock.Verify(f => f.SendMessage(MessagingConstants.CAMERA_MATRIX_TOPIC, It.IsAny<IMessage>()), Times.Once());
        }

        /// <summary>
        /// Test for the Terminate method on the Camera Component
        /// </summary>
        [TestMethod]
        public void CameraComponentTerminateTest()
        {
            CameraComponent target = new CameraComponent();
            PrivateObject obj = new PrivateObject(target);
            Mock<ILogger> loggerMock = new Mock<ILogger>();
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
            obj.SetFieldOrProperty("mLogger", loggerMock.Object);
            obj.SetFieldOrProperty("mContext", execContextMock.Object);
            obj.SetFieldOrProperty("mName", "TESTNAME");

            target.Terminate();

            loggerMock.Verify(f => f.Terminate(), Times.Once());
            msgRouterMock.Verify(f => f.DeregisterTopic("TESTNAME", target), Times.Once());
        }
    }
}
