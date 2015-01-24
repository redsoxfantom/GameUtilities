using GameUtilities.Framework.Utilities.ExecutableContext;
using GameUtilities.Framework.Utilities.Message;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameUtilities.Services
{
    /// <summary>
    /// Service providing utilities for creating Shaders
    /// </summary>
    public class ShaderService : BaseService
    {
        /// <summary>
        /// Initialize the Service. Register for all needed Topics
        /// </summary>
        /// <param name="context">the services executable context</param>
        public override void Init(IExecutableContext context)
        {
            base.Init(context);
            mContext.MessageRouter.RegisterTopic(MessagingConstants.SHADER_SERVICE_TOPIC, this);
        }

        /// <summary>
        /// Update the Shader Service
        /// </summary>
        /// <param name="timeSinceLastFrame">Time since last frame</param>
        /// <param name="messages">Dictionary of messages</param>
        public override void Update(double timeSinceLastFrame, Dictionary<string, List<IMessage>> messages)
        {
            object retObj = new object();

            foreach(string Topic in messages.Keys)
            {
                foreach(IMessage message in messages[Topic])
                {
                    HandleMessage(Topic, message, ref retObj);
                }
            }
        }

        /// <summary>
        /// Handle incoming messages
        /// </summary>
        /// <param name="Topic">Topic the message came from</param>
        /// <param name="message">The message object</param>
        /// <param name="returnValue">The returned object</param>
        /// <returns>Whether or not the call succeded</returns>
        public override bool HandleMessage(string Topic, IMessage message, ref object returnValue)
        {
            Type messageType = message.GetType();
            mLogger.Debug(string.Format("ShaderService got message of type {0}", messageType));

            if(messageType == typeof(LoadShaderProgramMessage))
            {
                int ShaderProgramId = GL.CreateProgram();

                Dictionary<ShaderType, string> shaderFileDictionary = (Dictionary<ShaderType, string>)message.GetData();
                foreach(ShaderType type in shaderFileDictionary.Keys)
                {
                    string file = mContext.ConfigManager.FindShader(shaderFileDictionary[type]);
                    try
                    {
                        LoadShaderFile(file, type, ShaderProgramId);
                    }
                    catch(Exception e)
                    {
                        GL.DeleteProgram(ShaderProgramId);
                        mLogger.Error(string.Format("Failed to create requested shader {0}:{1}",type,file), e);
                        return false;
                    }
                }

                mLogger.Debug(string.Format("Successfully created shader {0}", ShaderProgramId));
                returnValue = ShaderProgramId;
                return true;
            }

            return base.HandleMessage(Topic, message, ref returnValue);
        }

        /// <summary>
        /// Load a shader from the file and add it to the program
        /// </summary>
        /// <param name="filename">The name of the file to add</param>
        /// <param name="type">the type of shader to create</param>
        /// <param name="shaderProgram">the shader program to add this shader too</param>
        private void LoadShaderFile(String filename, ShaderType type, int shaderProgram)
        {
            int address = GL.CreateShader(type);
            int result = 0;
            using(StreamReader reader = new StreamReader(filename))
            {
                GL.ShaderSource(address, reader.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(shaderProgram, address);

            GL.GetShader(address,ShaderParameter.CompileStatus,out result);
            if(result == 0)
            {
                mLogger.Error(string.Format("Failed to create shader!\nShader: {0}, Error: {1}",filename,GL.GetShaderInfoLog(address)));
                throw new Exception("Shader Error");
            }
        }
    }
}
