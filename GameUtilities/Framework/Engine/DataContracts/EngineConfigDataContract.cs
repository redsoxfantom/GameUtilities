using GameUtilities.Framework.Utilities.Loggers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameUtilities.Framework.Engine.DataContracts
{
    /// <summary>
    /// Data contract for Engine Config files 
    /// </summary>
    [DataContract(Name="EngineConfig",Namespace="")]
    public class EngineConfigDataContract
    {
        /// <summary>
        /// The list of Services that this Engine supports
        /// </summary>
        [DataMember(Name="ServicesList", IsRequired=true,Order=0)]
        public List<string> ServicesList { get; private set; }

        /// <summary>
        /// The Type of logger this Engine will use
        /// </summary>
        [DataMember(Name="LoggerType",IsRequired=true,Order=1)]
        public string LoggerType { get; private set; }

        /// <summary>
        /// The level of logging the Engine should report. If not defined, log everything (Loglevel = DEBUG)
        /// </summary>
        [DataMember(Name="LogLevel",IsRequired=false,Order=2)]
        private string mLogLevel { get; set; }

        /// <summary>
        /// The Log level of the engine.
        /// </summary>
        public LoggerLevel LogLevel
        {
            get
            {
                if(mLogLevel == null)
                {
                    return LoggerLevel.DEBUG;
                }
                else
                {
                    try
                    {
                        return (LoggerLevel)Enum.Parse(typeof(LoggerLevel), mLogLevel);
                    }
                    catch(Exception)
                    {
                        Console.WriteLine(string.Format("***\nWARNING! FAILED TO PARSE LOGGER LEVEL FROM CONFIG (VALUE WAS {0})! DEFAULTING TO \"DEBUG\"\n***",mLogLevel));
                        return LoggerLevel.DEBUG;
                    }
                }
            }
        }


        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="mServices">A list of services that this engine supports</param>
        public EngineConfigDataContract(List<string> mServices)
        {
            ServicesList = mServices;
        }
    }
}
