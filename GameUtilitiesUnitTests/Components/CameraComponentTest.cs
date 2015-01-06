using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Components;
using GameUtilities.Framework.DataContracts;
using GameUtilities.Components.Constants.Camera;
using GameUtilities.Framework.ExecutableContext;

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
        public void CameraInitTestSuccess()
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
        }
    }
}
