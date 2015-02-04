using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameUtilities.Services;
using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message.MessageDispatch;
using GameUtilities.Framework.Utilities.Message;
using GameUtilitiesUnitTests.UnitTestUtilities;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using GameUtilities.Framework.Utilities.FilePathResolver;
using OpenTK;

namespace GameUtilitiesUnitTests.Services
{
    /// <summary>
    /// Test of the ShaderService class
    /// </summary>
    [TestClass]
    public class ShaderServiceTest
    {
        /// <summary>
        /// Test of the ShaderService init method
        /// Verify it registers for Topics
        /// </summary>
        [TestMethod]
        public void ShaderServiceInitTest()
        {
            ShaderService target = new ShaderService();
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);

            target.Init(execContextMock.Object);

            msgRouterMock.Verify(f => f.RegisterTopic(MessagingConstants.SHADER_SERVICE_TOPIC,target));
        }

        /// <summary>
        /// Test of the ShaderService terminate method
        /// Verify it deregisters for topics
        /// </summary>
        [TestMethod]
        public void ShaderServiceTerminateTest()
        {
            ShaderService target = new ShaderService();
            Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
            Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
            execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
            target.Init(execContextMock.Object);

            target.Terminate();

            msgRouterMock.Verify(f => f.DeregisterTopic(MessagingConstants.SHADER_SERVICE_TOPIC, target));
        }

        /// <summary>
        /// Test the Shaderservice message handler when given an unrecognized message
        /// </summary>
        [TestMethod]
        public void ShaderServiceHandleUnrecognizedMessage()
        {
            ShaderService target = new ShaderService();
            PrivateObject obj = new PrivateObject(target);
            LoggerUtility logger = new LoggerUtility("Logger");
            obj.SetFieldOrProperty("mLogger", logger);
            Mock<IMessage> mockMessage = new Mock<IMessage>();
            object test = new object();

            bool actual = target.HandleMessage("TEST", mockMessage.Object, ref test);

            bool expected = false;
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(logger.WarnMessages.Count == 1);
        }

        /// <summary>
        /// Test for the shaderservice when asked to create a shader program from one shader file that exists
        /// </summary>
        [TestMethod]
        public void ShaderServiceHandleOneShaderSuccessfulRequest()
        {
            using (var game = new GameWindow())
            {
                ShaderService target = new ShaderService();
                PrivateObject obj = new PrivateObject(target);
                LoggerUtility logger = new LoggerUtility("Logger");
                obj.SetFieldOrProperty("mLogger", logger);
                LoadShaderProgramMessage msg = new LoadShaderProgramMessage();
                ConfigManager config = new ConfigManager();
                object retObj = new object();
                Dictionary<ShaderType, string> msgData = new Dictionary<ShaderType, string>();
                msgData.Add(ShaderType.FragmentShader, "test_fragment_shader.frag");
                Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
                Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
                execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
                execContextMock.Setup(f => f.ConfigManager).Returns(config);
                config.Init(".\\TestConfig\\");
                msg.Init(msgData);
                target.Init(execContextMock.Object);

                bool actual = target.HandleMessage(MessagingConstants.SHADER_SERVICE_TOPIC, msg, ref retObj);

                int shaderProgramId = (int)retObj;
                Assert.IsTrue(shaderProgramId != 0);
                Assert.IsTrue(actual);
            }
        }

        /// <summary>
        /// Test for the shaderservice when asked to create a shader program from two shader files that exists
        /// </summary>
        [TestMethod]
        public void ShaderServiceHandleMultipleShadersSuccessfulRequest()
        {
            using (var game = new GameWindow())
            {
                ShaderService target = new ShaderService();
                PrivateObject obj = new PrivateObject(target);
                LoggerUtility logger = new LoggerUtility("Logger");
                obj.SetFieldOrProperty("mLogger", logger);
                LoadShaderProgramMessage msg = new LoadShaderProgramMessage();
                ConfigManager config = new ConfigManager();
                object retObj = new object();
                Dictionary<ShaderType, string> msgData = new Dictionary<ShaderType, string>();
                msgData.Add(ShaderType.FragmentShader, "test_fragment_shader.frag");
                msgData.Add(ShaderType.VertexShader, "test_vertex_shader.vert");
                Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
                Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
                execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
                execContextMock.Setup(f => f.ConfigManager).Returns(config);
                config.Init(".\\TestConfig\\");
                msg.Init(msgData);
                target.Init(execContextMock.Object);

                bool actual = target.HandleMessage(MessagingConstants.SHADER_SERVICE_TOPIC, msg, ref retObj);

                int shaderProgramId = (int)retObj;
                Assert.IsTrue(shaderProgramId != 0);
                Assert.IsTrue(actual);
            }
        }

        /// <summary>
        /// Test for the shaderservice when asked to create a shader program from one corrupt shader file that exists
        /// </summary>
        [TestMethod]
        public void ShaderServiceHandleOneShaderFailureRequest()
        {
            using (var game = new GameWindow())
            {
                ShaderService target = new ShaderService();
                PrivateObject obj = new PrivateObject(target);
                LoggerUtility logger = new LoggerUtility("Logger");
                obj.SetFieldOrProperty("mLogger", logger);
                LoadShaderProgramMessage msg = new LoadShaderProgramMessage();
                ConfigManager config = new ConfigManager();
                object retObj = new object();
                Dictionary<ShaderType, string> msgData = new Dictionary<ShaderType, string>();
                msgData.Add(ShaderType.FragmentShader, "test_bad_shader.vert");
                Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
                Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
                execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
                execContextMock.Setup(f => f.ConfigManager).Returns(config);
                config.Init(".\\TestConfig\\");
                msg.Init(msgData);
                target.Init(execContextMock.Object);

                bool actual = target.HandleMessage(MessagingConstants.SHADER_SERVICE_TOPIC, msg, ref retObj);

                Assert.IsFalse(actual);
                Assert.IsTrue(logger.ErrorMessages.Count == 2);
            }
        }

        /// <summary>
        /// Test for the shaderservice when asked to create a shader program from one shader file that does not exist
        /// </summary>
        [TestMethod]
        public void ShaderServiceHandleOneShaderDoesNotExist()
        {
            using (var game = new GameWindow())
            {
                ShaderService target = new ShaderService();
                PrivateObject obj = new PrivateObject(target);
                LoggerUtility logger = new LoggerUtility("Logger");
                obj.SetFieldOrProperty("mLogger", logger);
                LoadShaderProgramMessage msg = new LoadShaderProgramMessage();
                ConfigManager config = new ConfigManager();
                object retObj = new object();
                Dictionary<ShaderType, string> msgData = new Dictionary<ShaderType, string>();
                msgData.Add(ShaderType.FragmentShader, "BAD_FILE");
                Mock<IExecutableContext> execContextMock = new Mock<IExecutableContext>();
                Mock<IMessageRouter> msgRouterMock = new Mock<IMessageRouter>();
                execContextMock.Setup(f => f.MessageRouter).Returns(msgRouterMock.Object);
                execContextMock.Setup(f => f.ConfigManager).Returns(config);
                config.Init(".\\Config\\");
                msg.Init(msgData);
                target.Init(execContextMock.Object);

                bool actual = target.HandleMessage(MessagingConstants.SHADER_SERVICE_TOPIC, msg, ref retObj);

                int shaderProgramId = (int)retObj;
                Assert.IsTrue(shaderProgramId == 0);
                Assert.IsFalse(actual);
                Assert.IsTrue(logger.ErrorMessages.Count == 1);
            }
        }
    }
}
