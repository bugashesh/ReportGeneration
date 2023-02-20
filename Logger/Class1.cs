using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Library;
using static System.Net.Mime.MediaTypeNames;
using Org.BouncyCastle.Asn1.Cms;

namespace Library
{
    public enum LogLevel
    {
        None,
        Error,
        Exception,
        Info
    }

    public class Logger
    {
        private static LogLevel logLevel = LogLevel.Info;
        private static bool timeFilterEnabled = false;
        private static int logCount = 0;
        private static float startTime = Time.time;

        private static readonly Dictionary<LogLevel, string> logSections = new Dictionary<LogLevel, string>
        {
              { LogLevel.Error, "ERROR:" },
              { LogLevel.Exception, "EXCEPTION:" },
              { LogLevel.Info, "INFO:" }
        };

        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level <= logLevel)
            {
                logCount++;

                if (timeFilterEnabled)
                {
                    float elapsedTime = Time.time - startTime;
                    message = string.Format("[{0:0.00}s][{1}] {2}", elapsedTime, logCount, message);
                }

                string section = logSections[level];
                string formattedMessage = string.Format("[{0}] {1}", section, message);

                if (Application.isEditor)
                {
                    Debug.Log(formattedMessage);
                }
                else
                {
                    Console.WriteLine(formattedMessage);
                }
            }
        }

        public static void Error(string message)
        {
            Log(message, LogLevel.Error);
        }

        public static void Exception(Exception exception)
        {
            Log(exception.ToString(), LogLevel.Exception);
        }

        public static void SetLogLevel(LogLevel level)
        {
            logLevel = level;
        }

        public static void SetTimeFilterEnabled(bool enabled)
        {
            timeFilterEnabled = enabled;
        }


    }
}