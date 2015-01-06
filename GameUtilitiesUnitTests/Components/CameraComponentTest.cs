using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Components;
using GameUtilities.Framework.DataContracts;
using GameUtilities.Components.Constants.Camera;
using GameUtilities.Framework.ExecutableContext;
using OpenTK;

namespace GameUtilitiesUnitTests.Components
{
    /// <summary>
    /// Test for the CameraComponent class
    /// </summary>
    [TestClass]
    public class CameraComponentTest
    {
        /// <summary>
        /// Successful test of the init method
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
            contextMock.Setup(f => f.Entity.Name).Returns("TEST");


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
    }
}
