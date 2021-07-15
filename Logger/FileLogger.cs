/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileLogger.cs
 *  Description  :  Loggger for log to local file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;

namespace MGS.Logger
{
    /// <summary>
    /// Loggger for log to local file.
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Field and Property
        /// <summary>
        /// Root directory of log files.
        /// </summary>
        public string RootDir { get; }

        /// <summary>
        /// Filter for log content.
        /// </summary>
        public IFilter Filter { set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// Logs a formatted message to local file.
        /// </summary>
        /// <param name="tag">Tag of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        protected virtual void LogToFile(string tag, string format, params object[] args)
        {
            if (Filter != null && !Filter.Select(tag, format, args))
            {
                return;
            }

            var logFilePath = ResolveLogFile(RootDir);
            try
            {
                var dir = Path.GetDirectoryName(logFilePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var logContent = ResolveLogContent(tag, format, args);
                File.AppendAllText(logFilePath, logContent);
            }
#if DEBUG
                catch (Exception ex)
                {
                    throw ex;
                }
#else
            catch { }
#endif
        }

        /// <summary>
        /// Resolve the path of log file.
        /// </summary>
        /// <param name="rootDir">Root directory of log files.</param>
        /// <returns>The path of log file.</returns>
        protected virtual string ResolveLogFile(string rootDir)
        {
            var fileName = DateTime.Now.ToString("MM-dd-yyyy");
            return string.Format("{0}/{1}.log", rootDir, fileName);
        }

        /// <summary>
        /// Resolve the log content.
        /// </summary>
        /// <param name="tag">Tag of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        /// <returns>The log content.</returns>
        protected virtual string ResolveLogContent(string tag, string format, params object[] args)
        {
            var logTimeStamp = DateTime.Now.ToLongTimeString();
            var formatMsg = string.Format(format, args);
            return string.Format("{0}-{1}-{2}\r\n\r\n", logTimeStamp, tag, formatMsg);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootDir">Root directory of log files.</param>
        /// <param name="filter">Filter for log content.</param>
        public FileLogger(string rootDir, IFilter filter = null)
        {
            RootDir = rootDir;
            Filter = filter;
        }

        /// <summary>
        /// Logs a formatted message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void Log(string format, params object[] args)
        {
            LogToFile("LOG", format, args);
        }

        /// <summary>
        /// Logs a formatted error message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogError(string format, params object[] args)
        {
            LogToFile("ERROR", format, args);
        }

        /// <summary>
        /// Logs a formatted warning message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarning(string format, params object[] args)
        {
            LogToFile("WARNING", format, args);
        }
        #endregion
    }
}