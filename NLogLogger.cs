using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Logging.NLog
{
	/// <summary>
	/// Logger writing entries using NLog.
	/// </summary>
	public class NLogLogger : ILogger
	{
		#region Private fields

		private readonly global::NLog.Logger logger;

		#endregion

		#region Construction

		internal NLogLogger(global::NLog.Logger logger)
		{
			if (logger == null) throw new ArgumentNullException(nameof(logger));

			this.logger = logger;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.</param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.
		/// </param>
		public void Log(LogLevel logLevel, string message, params object[] arguments)
			=> logger.Log(TranslateLogLevel(logLevel), message, arguments);

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="message">
		/// The message for the log entry, optionally in a <see cref="String.Format(string, object[])"/>
		/// form when there are <paramref name="arguments"/>.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, Exception exception, string message, params object[] arguments)
			=> logger.Log(TranslateLogLevel(logLevel), exception, message, arguments);

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, IFormatProvider formatProvider, string message, params object[] arguments)
			=> logger.Log(TranslateLogLevel(logLevel), formatProvider, message, arguments);

		/// <summary>
		/// Write an entry to the registered log writers.
		/// </summary>
		/// <param name="logLevel">The severity level of the log entry.</param>
		/// <param name="exception">The exception to record in the log entry.</param>
		/// <param name="formatProvider">The formatter to use for the <paramref name="message"/>.</param>
		/// <param name="message">
		/// The message for the log entry, in a <see cref="String.Format(IFormatProvider, string, object[])"/> form.
		/// </param>
		/// <param name="arguments">Optional arguments to format the <paramref name="message"/>.</param>
		public void Log(LogLevel logLevel, Exception exception, IFormatProvider formatProvider, string message, params object[] arguments)
			=> logger.Log(TranslateLogLevel(logLevel), exception, formatProvider, message, arguments);

		#endregion

		#region Private methods

		private global::NLog.LogLevel TranslateLogLevel(LogLevel logLevel)
		{
			switch (logLevel)
			{
				case LogLevel.Trace:
					return global::NLog.LogLevel.Trace;

				case LogLevel.Debug:
					return global::NLog.LogLevel.Debug;

				case LogLevel.Warn:
					return global::NLog.LogLevel.Warn;

				case LogLevel.Error:
					return global::NLog.LogLevel.Error;

				case LogLevel.Fatal:
					return global::NLog.LogLevel.Fatal;

				default:
					return global::NLog.LogLevel.Info;
			}
		}

		#endregion
	}
}
