﻿// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="">
// Triangle.NET code by Christian Woltering, http://triangle.codeplex.com/
// </copyright>
// -----------------------------------------------------------------------

namespace TriangleNet
{
    using System;
    using System.Collections.Generic;

    public enum LogLevel { Info, Warning, Error }

    /// <summary>
    /// Represents an item stored in the log.
    /// </summary>
    public class LogItem
    {
        private readonly DateTime time;
        private readonly LogLevel level;
        private readonly string message;
        private readonly string details;

        /// <summary>
        /// Gets the <see cref="DateTime"/> the item was logged.
        /// </summary>
        public DateTime Time => time;

        /// <summary>
        /// Gets the <see cref="LogLevel"/>.
        /// </summary>
        public LogLevel Level => level;

        /// <summary>
        /// Gets the log message.
        /// </summary>
        public string Message => message;

        /// <summary>
        /// Gets further details of the log message.
        /// </summary>
        public string Details => details;

        /// <summary>
        /// Creates a new instance of the <see cref="LogItem"/> class.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The log message.</param>
        public LogItem(LogLevel level, string message)
            : this(level, message, "")
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="LogItem"/> class.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The log message.</param>
        /// <param name="details">The message details.</param>
        public LogItem(LogLevel level, string message, string details)
        {
            time = DateTime.Now;

            this.level = level;
            this.message = message;
            this.details = details;
        }
    }

    /// <summary>
    /// A simple logger, which logs messages to a List.
    public sealed class Log
    {
        /// <summary>
        /// Log detailed information.
        /// </summary>
        public static bool Verbose { get; set; }

        /// <summary>
        /// Gets all log messages.
        /// </summary>
        public IList<LogItem> Data => data;

        private readonly List<LogItem> data = new List<LogItem>();

        #region Singleton pattern

        // Singleton pattern as proposed by Jon Skeet:
        // https://csharpindepth.com/Articles/Singleton

        private static readonly Log instance = new Log();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Log() { }

        private Log() { }

        public static Log Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        /// <summary>
        /// Adds a <see cref="LogItem"/> to the log.
        /// </summary>
        /// <param name="item"></param>
        public void Add(LogItem item)
        {
            data.Add(item);
        }

        /// <summary>
        /// Clear all messages from the log.
        /// </summary>
        public void Clear()
        {
            data.Clear();
        }

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            data.Add(new LogItem(LogLevel.Info, message));
        }

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="details">Message details, for example the code location where the error occured (class, method).</param>
        public void Warning(string message, string details)
        {
            data.Add(new LogItem(LogLevel.Warning, message, details));
        }

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="details">Message details, for example the code location where the error occured (class, method).</param>
        public void Error(string message, string details)
        {
            data.Add(new LogItem(LogLevel.Error, message, details));
        }
    }
}
